using Gameplay;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EffectCaster : ITickable
    {
        private Transform _target;
        private Entity _self;
        private float _timer;
        private bool _isEnabled;

        public EffectCaster(Entity self)
        {
            _self = self;
        }

        public void Tick()
        {
            if (_timer == -1)
            {
                _self.transform.position = _target.transform.position;
                return;
            }

            if (_isEnabled)
            {
                _timer -= Time.deltaTime;
                if (_timer > 0)
                {
                    _self.transform.position = _target.transform.position;
                }
                else
                {
                    _self.Dispose();
                    _isEnabled = false;
                }
            }
        }

        public void CastEffect(Transform target, float duration)
        {
            _target = target;
            _timer = duration;
            _isEnabled = true;
        }
    }
}