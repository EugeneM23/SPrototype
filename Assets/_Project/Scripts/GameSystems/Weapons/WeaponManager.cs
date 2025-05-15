using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponManager
    {
        DiContainer _container;
        private GameObject _weaponPrefab;
        public GameObject CurrentWeapon { get; private set; }

        public WeaponManager(DiContainer container, GameObject weaponPrefab)
        {
            _container = container;
            _weaponPrefab = weaponPrefab;
            CurrentWeapon = _container.InstantiatePrefab(_weaponPrefab);
        }
    }
}