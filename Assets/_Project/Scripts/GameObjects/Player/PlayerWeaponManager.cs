using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class PlayerWeaponManager : IInitializable
    {
        private readonly Inventory _inventory;
        private Entity _currentWeapon;
        private readonly Button _button;
        private int _index;

        public Entity CurrentWeapon
        {
            get
            {
                if (_currentWeapon == null && _inventory.WeaponCount > 0)
                    _currentWeapon = _inventory[0];

                return _currentWeapon;
            }
            private set => _currentWeapon = value;
        }

        public PlayerWeaponManager(Button button, Inventory inventory)
        {
            _button = button;
            _inventory = inventory;
        }

        public void Initialize()
        {
            _button.onClick.AddListener(SwitchItem);
            _inventory.OnWeaponAdded += SetCurrentWeapon;
        }

        private void UnequipWeapon(Entity weapon)
        {
            if (weapon == null) return;

            weapon.gameObject.SetActive(false);
            weapon.Get<WeaponFireController>().TurnOff();
        }

        private void EquipWeapon(Entity weapon)
        {
            if (weapon == null) return;

            weapon.Get<WeaponFireController>().TurnOn();
            weapon.gameObject.SetActive(true);
        }

        private void SetCurrentWeapon()
        {
            UnequipWeapon(CurrentWeapon);

            CurrentWeapon = _inventory[_inventory.WeaponCount - 1];
            _index = -1;

            EquipWeapon(CurrentWeapon);
        }

        public void SwitchItem()
        {
            if (_inventory.WeaponCount == 0) return;
            
            if (CurrentWeapon == null && _inventory.WeaponCount > 0)
                CurrentWeapon = _inventory[0];

            UnequipWeapon(CurrentWeapon);

            _index = (_index + 1) % _inventory.WeaponCount;
            Debug.Log(_index);

            CurrentWeapon = _inventory[_index];

            EquipWeapon(CurrentWeapon);
        }
    }

}