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

        public Entity CurrentWeapon
        {
            get
            {
                if (_currentWeapon == null)
                    _currentWeapon = _inventory[0];

                return _currentWeapon;
            }
            private set { }
        }

        private readonly Button _button;
        private int _index;

        public PlayerWeaponManager(Button button, Inventory inventory)
        {
            _button = button;
            _inventory = inventory;
        }

        public void Initialize()
        {
            _button.onClick.AddListener(SwitchItem);
        }

        public void SwitchItem()
        {
            if (CurrentWeapon == null)
                CurrentWeapon = _inventory[0];

            CurrentWeapon.gameObject.SetActive(false);
            CurrentWeapon.Get<WeaponFireController>().TurnOff();
            _index = (_index + 1) % _inventory.WeaponCount;
            CurrentWeapon = _inventory[_index];
            CurrentWeapon.gameObject.SetActive(true);
            CurrentWeapon.Get<WeaponFireController>().TurnOn();
        }
    }
}