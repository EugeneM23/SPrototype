using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerInventory : IInitializable, IEnumerable<Entity>, WeaponReloadComponent.IAction, IInventory
    {
        public event Action OnBulletCountChanget;
        public event Action OnWeaponAdded;

        private int _bulletCount;

        public int BulletCount
        {
            get => _bulletCount;
            set
            {
                _bulletCount = value;
                OnBulletCountChanget?.Invoke();
            }
        }

        private readonly Transform _weaponBone;

        private readonly List<Entity> _startWeapons;
        private readonly List<Entity> _weapons = new(10);
        private readonly DiContainer _container;

        public PlayerInventory([Inject(Id = DamageRootID.MeleeWeaponRoot)] Transform weaponBone, int bulletCount,
            List<Entity> startWeapons, DiContainer container)
        {
            _weaponBone = weaponBone;
            BulletCount = bulletCount;
            _startWeapons = startWeapons;
            _container = container;
        }

        public int WeaponCount => _weapons.Count;

        public void Initialize()
        {
            foreach (var item in _startWeapons)
                SpawnWeapon(item);

            if (_weapons.Count == 0) return;

            _weapons[0].gameObject.SetActive(true);
        }

        private void SpawnWeapon(Entity item)
        {
            foreach (var entity in _weapons)
                if (entity.name == item.name + "(Clone)")
                    return;

            var go = _container.InstantiatePrefab(item);
            var weapon = go.GetComponent<Entity>();
            weapon.transform.SetParent(_weaponBone);
            weapon.transform.position = _weaponBone.position;
            weapon.transform.rotation = _weaponBone.rotation;
            weapon.Get<WeaponFireController>().TurnOn();
            weapon.gameObject.SetActive(false);
            _weapons.Add(weapon);
            OnWeaponAdded?.Invoke();
        }

        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
        {
            return _weapons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Entity>)this).GetEnumerator();
        }

        public Entity this[int i] => _weapons[i];

        public void AddBullets(int count)
        {
            BulletCount += count;
            OnBulletCountChanget?.Invoke();
        }

        public void AddWeapon(Entity entity) => SpawnWeapon(entity);

        public void StartRealod()
        {
        }

        public void FinishReload() => OnBulletCountChanget?.Invoke();
    }
}