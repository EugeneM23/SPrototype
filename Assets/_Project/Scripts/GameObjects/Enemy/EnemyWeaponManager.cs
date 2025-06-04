using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyWeaponManager : IInitializable
    {
        [Inject(Id = DamageRootID.MeleeWeaponRoot)]
        private readonly Transform _meleeRoot;

        [Inject(Id = DamageRootID.RangeWeaponRoot)]
        private readonly Transform _rangeRoot;

        [Inject(Id = WeaponParameterID.MeleeWeapon, Optional = true)]
        private readonly Entity _meleeWeaponPrefab;

        [Inject(Id = WeaponParameterID.RangeWeapon, Optional = true)]
        private readonly Entity _rangeWeaponPrefab;

        private readonly Entity _weaponMelee;
        private readonly Entity _weaponRange;
        public Entity CurrentWeapon { get; private set; }

        private readonly DiContainer _container;

        public EnemyWeaponManager(DiContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            if (_meleeWeaponPrefab != null)
                SpawnWeapon(_meleeWeaponPrefab, _meleeRoot);

            if (_rangeWeaponPrefab != null)
                SpawnWeapon(_rangeWeaponPrefab, _rangeRoot);
        }

        private void SpawnWeapon(Entity weapon, Transform meleeRoot)
        {
            CurrentWeapon = _container.InstantiatePrefab(weapon).GetComponent<Entity>();
            CurrentWeapon.transform.position = meleeRoot.position;
            CurrentWeapon.transform.rotation = meleeRoot.rotation;
            CurrentWeapon.transform.SetParent(meleeRoot);
            CurrentWeapon.Get<WeaponFireController>().TurnOn();
        }

        public void SetMeleeWeapon(Entity meleeWeapon) => SpawnWeapon(meleeWeapon, _meleeRoot);
        public void SetRangeWeapon(Entity weaponRange) => SpawnWeapon(weaponRange, _rangeRoot);
    }
}