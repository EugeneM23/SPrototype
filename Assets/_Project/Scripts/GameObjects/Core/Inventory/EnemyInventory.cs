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
        private readonly Entity _character;
        private readonly Entity _rangeWeaponPrefab;
        private readonly Entity _meleeWeaponPrefab;

        public Entity RangeWeapon { get; private set; }
        public Entity MeleeWeapon { get; private set; }

        public EnemyInventory(DiContainer container, Entity rangeWeapon, Entity meleeWeapon,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity character)
        {
            _container = container;
            _rangeWeaponPrefab = rangeWeapon;
            _meleeWeaponPrefab = meleeWeapon;
            _character = character;
        }

        public void Initialize()
        {
            if (_character.TryGet<EnemyRangeAttackState>(out var rangeState))
            {
                RangeWeapon = CreateWeapon(_rangeWeaponPrefab, _rangeWeaponRoot);
                rangeState.SetFireRate(RangeWeapon.Get<RangedWeaponConfig>().fireRate);
            }

            if (_character.TryGet<EnemyMeleeAttackState>(out var meleeState))
            {
                MeleeWeapon = CreateWeapon(_meleeWeaponPrefab, _meleeWeaponRoot);
                meleeState.SetFireRate(MeleeWeapon.Get<MeleeWeaponConfig>().fireRate);
            }
        }

        private Entity CreateWeapon(Entity prefab, Transform parent)
        {
            var weaponObject = _container.InstantiatePrefab(prefab);
            var weapon = weaponObject.GetComponent<Entity>();

            weapon.transform.SetParent(parent);
            weapon.transform.SetPositionAndRotation(parent.position, parent.rotation);
            weapon.Get<WeaponFireController>().TurnOn();
            
            if (weapon.TryGet<WeaponSlahController>(out var controller))
                controller.TurnOn();

            return weapon;
        }

        public int BulletCount
        {
            get => 100;
            set { }
        }

        public event Action OnBulletCountChanged;

        public void AddBullets(int bullets)
        {
        }
    }
}