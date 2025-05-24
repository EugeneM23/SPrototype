using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BackPackInstaller : MonoInstaller
    {
        [SerializeField] private int _bulletCount;
        [SerializeField] private GameObject _rangeWeapon;
        [SerializeField] private GameObject _melleWeapon;

        public override void InstallBindings()
        {
            Container.Bind<int>()
                .WithId(WeaponParameterID.BulletCount)
                .FromInstance(_bulletCount)
                .AsCached();

            Container.Bind<Entity>()
                .WithId(WeaponParameterID.MelleWeapon)
                .FromComponentInNewPrefab(_melleWeapon)
                .AsCached()
                .NonLazy();

            Container.Bind<Entity>()
                .WithId(WeaponParameterID.RangeWeapon)
                .FromComponentInNewPrefab(_rangeWeapon)
                .AsCached()
                .NonLazy();
        }
    }

    public class BackPack
    {
    }
}