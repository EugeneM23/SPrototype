using System;
using TMPro;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ClipUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentClip;
        [SerializeField] private TextMeshProUGUI _bulletCount;

        [Inject] private readonly PlayerCharacterProvider _player;

        private void Start() => transform.SetParent(_player.Character.transform);

        public void Enable() => gameObject.SetActive(true);

        public void Disable() => gameObject.SetActive(false);

        public void UpdateBulletCount(int value) => _bulletCount.SetText(value.ToString());

        public void UpdataCurrentCapacity(int value) => _currentClip.SetText(value.ToString() + " / ");
    }
}