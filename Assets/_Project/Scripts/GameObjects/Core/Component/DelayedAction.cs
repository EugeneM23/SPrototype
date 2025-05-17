using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class DelayedAction : ITickable
    {
        private float _timer;
        private bool _isActive;
        private Action _action;

        public void Schedule(float delay, Action action)
        {
            _timer = delay;
            _action = action;
            _isActive = true;
        }

        public void Tick()
        {
            if (!_isActive) return;

            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                _isActive = false;
                _action?.Invoke();
                _action = null;
            }
        }
    }
}