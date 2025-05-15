using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class PlayerWeaponManager : IInitializable
    {
        private readonly DiContainer _container;
        private GameObject[] _weaponPrefabs;
        private Transform _weponBone;
        private GameObject _currentWeapon;

        private List<GameObject> _weapons = new();
        private float _timer = 10;

        private readonly Button _button;
        private int _index;

        public PlayerWeaponManager(DiContainer container, GameObject[] weaponPrefab, Transform weponBone, Button button)
        {
            _container = container;
            _weaponPrefabs = weaponPrefab;
            _weponBone = weponBone;
            _button = button;
        }

        public void Initialize()
        {
            foreach (var item in _weaponPrefabs)
            {
                var weapon = _container.InstantiatePrefab(item);
                _weapons.Add(weapon);

                weapon.transform.SetParent(_weponBone);
                weapon.transform.position = _weponBone.transform.position;
                weapon.transform.transform.rotation = _weponBone.transform.rotation;
                weapon.SetActive(false);
            }

            _currentWeapon = _weapons[0];
            _currentWeapon.GetComponent<Entity>().Get<WeaponFireController>().TurnOn();
            _currentWeapon.SetActive(true);
            _button.onClick.AddListener(SwitchItem);
        }

        public void SwitchItem()
        {
            _currentWeapon.SetActive(false);
            _currentWeapon.GetComponent<Entity>().Get<WeaponFireController>().TurnOff();
            _index = (_index + 1) % _weaponPrefabs.Length;
            _currentWeapon = _weapons[_index];
            _currentWeapon.SetActive(true);
            _currentWeapon.GetComponent<Entity>().Get<WeaponFireController>().TurnOn();
        }
    }
}