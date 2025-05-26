using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Inventory : IInitializable, IEnumerable<Entity>, WeaponReloadComponent.IAction
    {
        public event Action OnBulletCountChanget;

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
        private readonly List<Entity> _weapons = new();
        private readonly DiContainer _container;

        public Inventory([Inject(Id = DamageRootID.MelleWeaponRoot)] Transform weaponBone, int bulletCount,
            List<Entity> startWeapons, DiContainer container)
        {
            _weaponBone = weaponBone;
            BulletCount = bulletCount;
            _startWeapons = startWeapons;
            _container = container;
        }

        public int WeaponCount => _startWeapons.Count;

        public void Initialize()
        {
            foreach (var item in _startWeapons)
            {
                var go = _container.InstantiatePrefab(item);
                var weapon = go.GetComponent<Entity>();
                weapon.transform.SetParent(_weaponBone);
                weapon.transform.position = _weaponBone.position;
                weapon.transform.rotation = _weaponBone.rotation;
                weapon.Get<WeaponFireController>().TurnOn();
                weapon.gameObject.SetActive(false);
                _weapons.Add(weapon);
            }

            _weapons[0].gameObject.SetActive(true);
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

        public void SetBullet(int count)
        {
            BulletCount += count;
            OnBulletCountChanget?.Invoke();
            Debug.Log(BulletCount);
        }

        public void StartRealod()
        {
        }

        public void FinishReload()
        {
            OnBulletCountChanget?.Invoke();
        }
    }
}