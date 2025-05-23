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

        [Inject(Id = WeaponParameterID.ReloadTime)]
        private float _reloadTime;

        private void Start()
        {
            transform.SetParent(_player.Character.transform);
        }

        private void OnEnable()
        {
            _clip.OnCurrentCapacityChanget += UpdataCurrentCapacity;
            _clip.OnBulletCountChanget += UpdateBulletCount;
            _currentClip.SetText(_clip.CurrentCapacity.ToString() + " / ");
            _bulletCount.SetText(_clip.BulletCount.ToString());
        }

        private void OnDisable()
        {
            _clip.OnCurrentCapacityChanget -= UpdataCurrentCapacity;
            _clip.OnBulletCountChanget -= UpdateBulletCount;
        }

        private void UpdateBulletCount(int value) => _bulletCount.SetText(value.ToString());

        public void UpdataCurrentCapacity(int value) => _currentClip.SetText(value.ToString() + " / ");
        
    }
}