using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class PlayerWeaponManager : IInitializable
    {
        private readonly PlayerInventory _playerInventory;
        private readonly Button switchButton;
        private readonly bool isPlayer;

        private Entity _currentWeapon;
        private int currentIndex = 0;

        public Entity CurrentWeapon => _currentWeapon;

        public PlayerWeaponManager(PlayerInventory playerInventory, Button switchButton = null, bool isPlayer = true)
        {
            this._playerInventory = playerInventory;
            this.switchButton = switchButton;
            this.isPlayer = isPlayer;
        }

        public void Initialize()
        {
            if (isPlayer && switchButton != null)
            {
                switchButton.onClick.AddListener(SwitchWeapon);
            }

            _playerInventory.OnWeaponAdded += OnWeaponAdded;

            if (_playerInventory.WeaponCount > 0)
            {
                EquipWeapon(_playerInventory[0]);
            }
        }

        private void OnWeaponAdded()
        {
            if (_currentWeapon == null)
            {
                EquipWeapon(_playerInventory[_playerInventory.WeaponCount - 1]);
            }
        }

        public void SwitchWeapon()
        {
            if (_playerInventory.WeaponCount <= 1) return;

            UnequipWeapon(_currentWeapon);
            currentIndex = (currentIndex + 1) % _playerInventory.WeaponCount;
            EquipWeapon(_playerInventory[currentIndex]);
        }

        private void EquipWeapon(Entity weapon)
        {
            if (weapon == null) return;

            _currentWeapon = weapon;
            weapon.gameObject.SetActive(true);
            weapon.Get<WeaponFireController>()?.TurnOn();
        }

        private void UnequipWeapon(Entity weapon)
        {
            if (weapon == null) return;

            weapon.gameObject.SetActive(false);
            weapon.Get<WeaponFireController>()?.TurnOff();
        }
    }
}