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
        public GameObject CurrentWeapon { get; private set; }

        public MelleWeaponManager(DiContainer container, GameObject weaponPrefab)
        {
            _container = container;
            _weaponPrefab = weaponPrefab;
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