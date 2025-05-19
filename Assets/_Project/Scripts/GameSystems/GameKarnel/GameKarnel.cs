using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameKarnel : MonoKernel
    {
        [SerializeField] private bool _isEnable;
        [Inject] private GameInput _gameInput;

        private void OnEnable()
        {
            _gameInput.OnPause += Pause();
        }

        private System.Action Pause()
        {
            return () => _isEnable = !_isEnable;
        }

        private void OnDisable()
        {
            _gameInput.OnPause -= Pause();
        }

        public override void Update()
        {
            if (_isEnable)
            {
                base.Update();
            }
        }
    }
}