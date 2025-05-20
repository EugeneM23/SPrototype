using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class RangeWeaponManager : IInitializable
    {
        [Inject(Id = ComponentsID.RangeWeaponRoot)]
        private readonly Transform _weapon;

        private readonly DiContainer _container;
        private readonly GameObject _weaponPrefab;
        public GameObject CurrentWeapon { get; private set; }

        public RangeWeaponManager(DiContainer container, GameObject weaponPrefab)
        {
            _container = container;
            _weaponPrefab = weaponPrefab;
        }

        public void Initialize()
        {
            CurrentWeapon = _container.InstantiatePrefab(_weaponPrefab);
            CurrentWeapon.transform.position = _weapon.position;
            CurrentWeapon.transform.SetParent(_weapon);
        }
    }
}