using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyMellWeaponManager : IInitializable
    {
        [Inject(Id = ComponentsID.MelleWeaponRoot)]
        private readonly Transform _melleRoot;

        private readonly DiContainer _container;
        private readonly GameObject _weaponPrefab;
        private readonly Entity _enemy;
        public GameObject CurrentWeapon { get; private set; }

        public EnemyMellWeaponManager(DiContainer container, GameObject weaponPrefab, Entity enemy)
        {
            _container = container;
            _weaponPrefab = weaponPrefab;
            _enemy = enemy;
        }

        public void Initialize()
        {
            CurrentWeapon = _container.InstantiatePrefab(_weaponPrefab);
            CurrentWeapon.transform.position = _melleRoot.position;
            CurrentWeapon.transform.SetParent(_melleRoot);
            CurrentWeapon.GetComponent<Entity>().Get<WeaponFireController>().TurnOn();
        }
    }

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