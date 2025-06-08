using AudioEngine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class RangedWeaponInstaller : BaseWeaponInstaller
    {
        [SerializeField] private RangedWeaponConfig rangedConfig;
        [SerializeField] private ClipUI _clipUI;
        [SerializeField] private ReloadStatusUI _reloadStatus;

        [Header("Ranged Components")] [SerializeField]
        private Transform firePoint;

        [SerializeField] private Transform shellPoint;
        [SerializeField] private Entity muzzleFlash;

        [Header("Prefabs")] [SerializeField] private Entity bulletPrefab;
        [SerializeField] private Entity shellPrefab;

        [Header("SFX")] [SerializeField] private AudioEventKey _shoot;

        public override void InstallBindings()
        {
            config = rangedConfig;
            Container.Bind<RangedWeaponConfig>().FromInstance(rangedConfig).AsSingle();
            base.InstallBindings();

            if (rangedConfig.isReloadable)
                SetupReload();
        }

        protected override void SetupWeaponSpecific()
        {
            if (bulletPrefab)
                Container.Bind<Entity>().WithId(WeaponParameterID.BulletPrefab).FromInstance(bulletPrefab);
            if (shellPrefab)
                Container.Bind<Entity>().WithId(WeaponParameterID.ShellPrefab).FromInstance(shellPrefab);

            Container.BindInterfacesTo<WeaponBulletSpawnAction>().AsSingle().WithArguments(firePoint);
            Container.BindInterfacesTo<WeaponShellSpawnAction>().AsSingle().WithArguments(shellPoint);
            Container.BindInterfacesTo<WeaponMuzzleFlashAction>().AsSingle().WithArguments(muzzleFlash, firePoint);
            Container.BindInterfacesTo<WeaponRangeAttackAction>().AsSingle().NonLazy();
            Container.BindInterfacesTo<WeaponShootSFXAction>().AsSingle().WithArguments(firePoint, _shoot)
                .NonLazy();
        }

        private void SetupReload()
        {
            Container.BindInterfacesAndSelfTo<WeaponReloadComponent>().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponSootCounAction>().AsSingle();
            Container.BindInterfacesAndSelfTo<ReloadAnimationAction>().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponClipComponent>().AsSingle()
                .WithArguments(rangedConfig.clipCapacity);
            Container.BindInterfacesAndSelfTo<WeaponClipController>().AsSingle();

            if (_reloadStatus != null)
            {
                Container.BindInterfacesAndSelfTo<ReloadStatusUI>().FromComponentInNewPrefab(_reloadStatus).AsSingle()
                    .NonLazy();
                Container.BindInterfacesAndSelfTo<ReloadStatusUIPresentor>().AsSingle().NonLazy();
            }

            if (_clipUI != null)
            {
                Container.BindInterfacesAndSelfTo<ClipUI>().FromComponentInNewPrefab(_clipUI).AsSingle().NonLazy();
                Container.BindInterfacesAndSelfTo<ClipUIPresentor>().AsSingle().NonLazy();
            }
        }
    }
}