using Gameplay.Installers;
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

        public override void InstallBindings()
        {
            GameObject go = new GameObject("BulletPool");

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
                .BindMemoryPool<Entity, BulletPool>()
                .FromComponentInNewPrefab(_bulletPrefab)
                .UnderTransform(go.transform);

            Container
                .Bind<IBulletSpawner>()
                .To<BulletPool>()
                .FromResolve();

            Container
                .BindMemoryPool<Shell, ShellPool>()
                .FromComponentInNewPrefab(_shellPrefab)
                .UnderTransform(go.transform);

            Container
                .Bind<IShellSpawner>()
                .To<ShellPool>()
                .FromResolve();

            Container
                .BindInterfacesAndSelfTo<WeaponFireController>()
                .AsSingle()
                .NonLazy();
            
        }
    }
}