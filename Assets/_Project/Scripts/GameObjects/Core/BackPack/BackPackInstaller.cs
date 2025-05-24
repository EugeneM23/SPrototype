using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BackPackInstaller : MonoInstaller
    {
        [SerializeField] private int _bulletCount;
        [SerializeField] private Entity _rangeWeapon;
        [SerializeField] private Entity _melleWeapon;

        public override void InstallBindings()
        {
            Container.Bind<int>()
                .WithId(WeaponParameterID.BulletCount)
                .FromInstance(_bulletCount)
                .AsCached();

            Container.Bind<Entity>()
                .WithId(WeaponParameterID.SecondWeapon)
                .FromComponentInNewPrefab(_melleWeapon)
                .AsCached()
                .NonLazy();

            Container.Bind<Entity>()
                .WithId(WeaponParameterID.FisrstWeapon)
                .FromComponentInNewPrefab(_rangeWeapon)
                .AsCached()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<BackPack>().AsSingle().NonLazy();
        }
    }
}