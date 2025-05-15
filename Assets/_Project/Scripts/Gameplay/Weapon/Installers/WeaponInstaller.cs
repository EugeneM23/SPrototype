using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Transform _shellPoint;
        [SerializeField] private WeaponSetings _setings;
        [SerializeField] private ParticleSystem _muzzleFlash;
        [SerializeField] private Entity _bulletPrefab;
        [SerializeField] private Entity _shellPrefab;
        [SerializeField] private Entity _weponModel;

        public override void InstallBindings()
        {
            GameObject go = new GameObject("BulletPool");


            Container
                .Bind<WeaponSetings>()
                .FromInstance(_setings)
                .AsSingle()
                .NonLazy();

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
                .AsSingle().WithArguments(_firePoint, _setings)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponColldownComponent>()
                .AsSingle()
                .WithArguments(_setings);

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
        }
    }
}