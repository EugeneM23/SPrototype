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

        private void OnEnable()
        {
            _clip.OnCurrentCapacityChanget += UpdataCurrentCapacity;
            _clip.OnBulletCountChanget += UpdateBulletCount;
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