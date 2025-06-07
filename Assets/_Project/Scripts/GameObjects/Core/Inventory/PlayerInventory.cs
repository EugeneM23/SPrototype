using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerInventory : IInitializable, IEnumerable<Entity>, WeaponReloadComponent.IAction, IInventory
    {
        public event Action OnBulletCountChanged;
        public event Action OnWeaponAdded;

        private int _bulletCount;
        private readonly Transform _weaponBone;
        private readonly List<Entity> _startWeapons;
        private readonly List<Entity> _weapons = new();
        private readonly DiContainer _container;

        public int BulletCount
        {
            get => _bulletCount;
            set
            {
                _bulletCount = value;
                OnBulletCountChanged?.Invoke();
            }
        }

        public int WeaponCount => _weapons.Count;
        public Entity this[int index] => _weapons[index];

        public PlayerInventory([Inject(Id = DamageRootID.MeleeWeaponRoot)] Transform weaponBone,
            int bulletCount, List<Entity> startWeapons, DiContainer container)
        {
            _weaponBone = weaponBone;
            _bulletCount = bulletCount;
            _startWeapons = startWeapons;
            _container = container;
        }

        public void Initialize()
        {
            foreach (var weapon in _startWeapons)
                SpawnWeapon(weapon);

            ActivateFirstWeapon();
        }

        private void ActivateFirstWeapon()
        {
            if (_weapons.Count > 0)
                _weapons[0].gameObject.SetActive(true);
        }

        private void SpawnWeapon(Entity weaponPrefab)
        {
            if (WeaponAlreadyExists(weaponPrefab))
                return;

            var weaponObject = _container.InstantiatePrefab(weaponPrefab);
            var weapon = weaponObject.GetComponent<Entity>();

            SetupWeapon(weapon);
            _weapons.Add(weapon);
            OnWeaponAdded?.Invoke();
        }

        private bool WeaponAlreadyExists(Entity weaponPrefab)
        {
            string weaponName = weaponPrefab.name + "(Clone)";
            return _weapons.Exists(w => w.name == weaponName);
        }

        private void SetupWeapon(Entity weapon)
        {
            weapon.transform.SetParent(_weaponBone);
            weapon.transform.SetPositionAndRotation(_weaponBone.position, _weaponBone.rotation);
            weapon.gameObject.SetActive(false);
        }

        public void AddBullets(int count)
        {
            BulletCount += count;
        }

        public void AddWeapon(Entity weapon) => SpawnWeapon(weapon);

        public void StartReload()
        {
        }

        public void FinishReload() => OnBulletCountChanged?.Invoke();

        public IEnumerator<Entity> GetEnumerator() => _weapons.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}