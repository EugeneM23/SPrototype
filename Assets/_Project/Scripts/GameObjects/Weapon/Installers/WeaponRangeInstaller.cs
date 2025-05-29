using Gameplay.Weapon;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponRangeInstaller : MonoInstaller
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Transform _shellPoint;
        [SerializeField] private ParticleSystem _muzzleFlash;
        [SerializeField] private Entity _bulletPrefab;
        [SerializeField] private Entity _shellPrefab;

        [SerializeField] private bool _isRelodeable;
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _clipCapacity;

        public override void InstallBindings()
        {
            Container.Bind<Entity>().WithId(WeaponParameterID.BulletPrefab).FromInstance(_bulletPrefab).AsCached();
            Container.Bind<Entity>().WithId(WeaponParameterID.ShellPrefab).FromInstance(_shellPrefab).AsCached();

            Container
                .Bind<WeaponShootComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<WeaponShellSpawnAction>()
                .AsSingle()
                .WithArguments(_shellPoint)
                .NonLazy();

            Container
                .BindInterfacesTo<WeaponShootAnimationAction>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponCameraShakeAction>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<WeaponMuzzleFlashAction>()
                .AsSingle()
                .WithArguments(_muzzleFlash)
                .NonLazy();

            Container
                .BindInterfacesTo<WeaponBulletSpawnAction>()
                .AsSingle().WithArguments(_firePoint)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponCooldownAction>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<WeaponFireController>()
                .AsSingle()
                .NonLazy();

            if (_isRelodeable)
            {
                Container.Bind<float>().WithId(WeaponParameterID.ReloadTime).FromInstance(_reloadTime).AsCached();
                Container.BindInterfacesAndSelfTo<WeaponReloadComponent>().AsSingle().NonLazy();
                Container.BindInterfacesAndSelfTo<WeaponSootCounAction>().AsSingle().NonLazy();
                Container.BindInterfacesAndSelfTo<ReloadAnimationAction>().AsSingle().NonLazy();
                Container.BindInterfacesAndSelfTo<WeaponClipComponent>().AsSingle().WithArguments(_clipCapacity)
                    .NonLazy();
                Container.BindInterfacesAndSelfTo<WeaponClipController>().AsSingle().NonLazy();
            }
        }
    }
}