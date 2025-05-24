using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class PlayerWeaponManager : IInitializable
    {
        private readonly BackPack _backpack;
        private Entity _currentWeapon;

        private readonly Button _button;
        private int _index;

        public PlayerWeaponManager(Button button, BackPack backpack)
        {
            _button = button;
            _backpack = backpack;
        }

        public void Initialize()
        {
            _button.onClick.AddListener(SwitchItem);
        }

        public void SwitchItem()
        {
            if (_currentWeapon == null)
                _currentWeapon = _backpack[0];

            _currentWeapon.gameObject.SetActive(false);
            _currentWeapon.Get<WeaponFireController>().TurnOff();
            _index = (_index + 1) % _backpack.WeaponCount;
            _currentWeapon = _backpack[_index];
            _currentWeapon.gameObject.SetActive(true);
            _currentWeapon.Get<WeaponFireController>().TurnOn();
        }
    }
}