using UnityEngine;

namespace Gameplay
{
    public class RangedWeaponInstaller : BaseWeaponInstaller
    {
        [SerializeField] private RangedWeaponConfig rangedConfig;

        [Header("Ranged Components")] [SerializeField]
        private Transform firePoint;

        [SerializeField] private Transform shellPoint;
        [SerializeField] private ParticleSystem muzzleFlash;

        [Header("Prefabs")] [SerializeField] private Entity bulletPrefab;
        [SerializeField] private Entity shellPrefab;

        public override void InstallBindings()
        {
            config = rangedConfig;
            Container.Bind<RangedWeaponConfig>().FromInstance(rangedConfig).AsSingle();
            base.InstallBindings();
        }

        protected override void SetupWeaponSpecific()
        {
            if (bulletPrefab)
                Container.Bind<Entity>().WithId(WeaponParameterID.BulletPrefab).FromInstance(bulletPrefab);
            if (shellPrefab)
                Container.Bind<Entity>().WithId(WeaponParameterID.ShellPrefab).FromInstance(shellPrefab);

            Container.BindInterfacesTo<WeaponBulletSpawnAction>().AsSingle().WithArguments(firePoint);
            Container.BindInterfacesTo<WeaponShellSpawnAction>().AsSingle().WithArguments(shellPoint);
            Container.BindInterfacesTo<WeaponMuzzleFlashAction>().AsSingle().WithArguments(muzzleFlash);
            Container.BindInterfacesTo<WeaponRangeAttackAction>().AsSingle().NonLazy();
        }
    }
}