using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyInventory : IInitializable, IInventory
    {
        [Inject(Id = DamageRootID.RangeWeaponRoot)]
        private readonly Transform _rangeWeaponRoot;

        [Inject(Id = DamageRootID.MeleeWeaponRoot)]
        private readonly Transform _meleeWeaponRoot;

        private readonly DiContainer _container;

        private Entity _rangeWepaonPrefab;
        private Entity _meleeWeaponPrefab;

        public Entity _rangeWepaon { get; private set; }
        public Entity _meleeWeapon { get; private set; }

        private readonly Entity _character;

        public EnemyInventory(DiContainer container, Entity rangeWepaon, Entity meleeWeapon,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity character)
        {
            _container = container;
            _rangeWepaonPrefab = rangeWepaon;
            _meleeWeaponPrefab = meleeWeapon;
            _character = character;
        }

        public void Initialize()
        {
            if (_character.TryGet<EnemyRangeAttackState>(out var rangeState))
            {
                SpawnRangeWeapon(_rangeWeaponRoot);
                rangeState.SetFireRate(_rangeWepaon.Get<RangedWeaponConfig>().fireRate);
            }

            if (_character.TryGet<EnemyMeleeAttackState>(out var meleeState))
            {
                SpawnMeleeWeapon(_meleeWeaponRoot);
                meleeState.SetFireRate(_meleeWeapon.Get<MeleeWeaponConfig>().fireRate);
            }
        }

        private void SpawnRangeWeapon(Transform parent)
        {
            var go = _container.InstantiatePrefab(_rangeWepaonPrefab);
            _rangeWepaon = go.GetComponent<Entity>();
            _rangeWepaon.transform.SetParent(parent);
            _rangeWepaon.transform.position = parent.position;
            _rangeWepaon.transform.rotation = parent.rotation;
            _rangeWepaon.Get<WeaponFireController>().TurnOn();
        }

        private void SpawnMeleeWeapon(Transform parent)
        {
            var go = _container.InstantiatePrefab(_meleeWeaponPrefab);
            _meleeWeapon = go.GetComponent<Entity>();
            _meleeWeapon.transform.SetParent(parent);
            _meleeWeapon.transform.position = parent.position;
            _meleeWeapon.transform.rotation = parent.rotation;
            _meleeWeapon.Get<WeaponFireController>().TurnOn();
        }

        public int BulletCount
        {
            get { return 100; }
            set { }
        }

        public event Action OnBulletCountChanget;
    }
}