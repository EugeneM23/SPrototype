using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ClipUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentClip;
        [SerializeField] private TextMeshProUGUI _bulletCount;
        [Inject] private readonly WeaponClipComponent _clip;
        [Inject] private DelayedAction _delayedAction;
        [Inject] private readonly PlayerCharacterProvider _player;
        [Inject] private readonly Entity _weaponEntity;
        [Inject] private readonly Inventory _inventory;

        [Inject(Id = WeaponParameterID.ReloadTime)]
        private float _reloadTime;

        private void Start()
        {
            transform.SetParent(_player.Character.transform);
        }

        private void OnEnable()
        {
            _weaponEntity.OnEntityDisable += () => gameObject.SetActive(false);
            _weaponEntity.OnEntityEnable += () => gameObject.SetActive(true);

            _clip.OnCurrentCapacityChanget += UpdataCurrentCapacity;
            _inventory.OnBulletCountChanget += UpdateBulletCount;

            _currentClip.SetText(_clip.CurrentCapacity.ToString() + " / ");
            _bulletCount.SetText(_inventory.BulletCount.ToString());
        }

        private void OnDisable()
        {
            _clip.OnCurrentCapacityChanget -= UpdataCurrentCapacity;
            _inventory.OnBulletCountChanget -= UpdateBulletCount;
        }

        private void UpdateBulletCount()
        {
            Debug.Log(_inventory.BulletCount);
            _bulletCount.SetText(_inventory.BulletCount.ToString());
        }

        public void UpdataCurrentCapacity(int value) => _currentClip.SetText(value.ToString() + " / ");

    }
}