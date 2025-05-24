using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BackPack : IInitializable, IEnumerable<Entity>
    {
        
        public int BulletCount;
        private readonly Entity _firstWeapon;
        private readonly Entity _secondWeapon;
        private readonly Transform _weaponBone;

        private readonly List<Entity> _weapons = new();

        public BackPack(
            [Inject(Id = WeaponParameterID.FisrstWeapon)]
            Entity firstWeapon,
            [Inject(Id = WeaponParameterID.SecondWeapon)]
            Entity secondWeapon,
            [Inject(Id = DamageRootID.MelleWeaponRoot)]
            Transform weaponBone,
            [Inject(Id = WeaponParameterID.BulletCount)]
            int bulletCount
            )
        {
            _firstWeapon = firstWeapon;
            _secondWeapon = secondWeapon;
            _weaponBone = weaponBone;
            BulletCount = bulletCount;
        }

        public int WeaponCount => _weapons.Count;

        public void Initialize()
        {
            _weapons.Add(_firstWeapon);
            _weapons.Add(_secondWeapon);

            foreach (var item in _weapons)
            {
                item.transform.SetParent(_weaponBone);
                item.transform.position = _weaponBone.position;
                item.transform.rotation = _weaponBone.rotation;
                item.Get<WeaponFireController>().TurnOn();
                item.gameObject.SetActive(false);

                if (item.TryGet<WeaponClipComponent>(out var clipComponent))
                    clipComponent._backpack = this;
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

        // Индексатор
        public Entity this[int i] => _weapons[i];
    }
}