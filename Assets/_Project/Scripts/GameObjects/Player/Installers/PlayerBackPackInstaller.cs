using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerBackPackInstaller : MonoInstaller
    {
        [SerializeField] private int _bulletCount;
        [SerializeField] private GameObject _rangeWeapon;
        [SerializeField] private GameObject _melleWeapon;

        public override void InstallBindings()
        {
            Container.
                Bind<int>()
                .WithId(WeaponParameterID.BulletCount)
                .FromInstance(_bulletCount)
                .AsCached();
            
            Container.
                Bind<Transform>()
                .WithId(WeaponParameterID.MelleWeapon)
                .FromComponentInNewPrefab(_melleWeapon)
                .AsCached();
            
            Container.
                Bind<Transform>()
                .WithId(WeaponParameterID.RangeWeapon)
                .FromComponentInNewPrefab(_rangeWeapon)
                .AsCached();
        }
    }
}