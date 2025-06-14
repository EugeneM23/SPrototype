using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class PlayerWeaponManager : IInitializable, IDisposable
    {
        private readonly Button switchButton;
        private readonly bool isPlayer;
        private readonly List<Entity> _weapons = new();

        private Entity _currentWeapon;
        private int currentIndex = 0;

        public Entity CurrentWeapon => _currentWeapon;

        public PlayerWeaponManager(Button switchButton = null, bool isPlayer = true)
        {
            this.switchButton = switchButton;
            this.isPlayer = isPlayer;
        }

        public void Initialize()
        {
            if (isPlayer && switchButton != null)
            {
                switchButton.onClick.AddListener(SwitchWeapon);
            }
        }

        public void Dispose()
        {
            if (isPlayer && switchButton != null)
            {
                switchButton.onClick.RemoveListener(SwitchWeapon);
            }
        }

        public void AddWeapon(Entity weapon)
        {
            _weapons.Add(weapon);

            if (_currentWeapon == null)
            {
                EquipWeapon(weapon);
                currentIndex = _weapons.Count - 1;
            }
        }

        public void SwitchWeapon()
        {
            if (_weapons.Count <= 1) return;

            UnequipWeapon(_currentWeapon);
            currentIndex = (currentIndex + 1) % _weapons.Count;
            EquipWeapon(_weapons[currentIndex]);
        }

        private void EquipWeapon(Entity weapon)
        {
            if (weapon == null) return;

            _currentWeapon = weapon;
            weapon.gameObject.SetActive(true);
            weapon.Get<WeaponFireController>()?.TurnOn();

            if (weapon.TryGet<WeaponSlahController>(out var controller))
                controller.TurnOn();
        }

        private void UnequipWeapon(Entity weapon)
        {
            weapon.gameObject.SetActive(false);
            weapon.Get<WeaponFireController>()?.TurnOff();

            if (weapon.TryGet<WeaponSlahController>(out var controller))
                controller.TurnOff();
        }
    }
}