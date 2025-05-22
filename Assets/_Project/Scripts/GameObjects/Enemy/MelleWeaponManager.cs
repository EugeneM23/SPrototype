using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MelleWeaponManager : IInitializable
    {
        [Inject(Id = DamageRootID.MelleWeaponRoot)]
        private readonly Transform _melleRoot;

        private readonly DiContainer _container;
        private readonly GameObject _weaponPrefab;
        private readonly Entity _enemy;
        public GameObject CurrentWeapon { get; private set; }

        public MelleWeaponManager(DiContainer container, GameObject weaponPrefab, Entity enemy)
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
}