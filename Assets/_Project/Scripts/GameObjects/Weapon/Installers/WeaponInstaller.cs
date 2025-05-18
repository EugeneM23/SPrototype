using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponInstaller : MonoInstaller
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
                .BindInterfacesTo<WeaponShellSpawnComponent>()
                .AsSingle()
                .WithArguments(_shellPoint)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponCameraShaceComponent>()
                .AsSingle()
                .NonLazy();


            Container
                .BindInterfacesTo<WeaponMuzzleFlashComponent>()
                .AsSingle()
                .WithArguments(_muzzleFlash)
                .NonLazy();

            Container
                .Bind<WeaponShootComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<WeaponBulletSpawnComponent>()
                .AsSingle().WithArguments(_firePoint)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponCooldownComponent>()
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

            Container
                .BindInterfacesAndSelfTo<WeaponTargetController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<WeaponTargetComponent>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<RangeProjectileSpawn>()
                .AsSingle()
                .NonLazy();
        }
    }
}