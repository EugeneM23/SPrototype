using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponManager : IInitializable
    {
        DiContainer _container;
        private readonly GameObject _weaponPrefab;
        private readonly Transform _weaponRoot;
        public GameObject CurrentWeapon { get; private set; }

        public WeaponManager(DiContainer container, GameObject weaponPrefab, Transform weaponRoot)
        {
            _container = container;
            _weaponPrefab = weaponPrefab;
            _weaponRoot = weaponRoot;
        }

        public void Initialize()
        {
            CurrentWeapon = _container.InstantiatePrefab(_weaponPrefab);
            CurrentWeapon.transform.position = _weaponRoot.position;
            CurrentWeapon.transform.SetParent(_weaponRoot);
        }
    }
}