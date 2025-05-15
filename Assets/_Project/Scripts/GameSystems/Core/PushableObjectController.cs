using UnityEngine;
using Zenject;

namespace Gameplay
{
    internal class PushableObjectController : IInitializable
    {
        private readonly PushComponent _pushComponent;
        private readonly HealthComponentBase _healthComponent;
        private readonly EnemyBlackBoard _blackboard;

        public PushableObjectController(PushComponent pushComponent, EnemyBlackBoard blackboard)
        {
            _pushComponent = pushComponent;
            _blackboard = blackboard;
        }

        public void SetImpulse(Vector3 direction, float impulsPower, float impulstime)
        {
            if (_blackboard.CanPush)
                _pushComponent.SetImpulse(direction, impulsPower, impulstime);
        }

        public void Initialize()
        {
            _blackboard.CanPush = true;
        }
    }

    public class PushComponent : ITickable
    {
        private Vector3 _direction;
        private float _impulsPower;
        private float _timer;
        private bool _isOnimpulse;

        private Rigidbody _rigidbody;

        public PushComponent(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Tick()
        {
            if (_timer <= 0) return;

            _timer -= Time.deltaTime;
            if (_timer > 0)
            {
                if (_isOnimpulse == false)
                {
                    _isOnimpulse = true;
                    _rigidbody.AddForce(_direction * _impulsPower, ForceMode.Impulse);
                }
            }
            else
            {
                _isOnimpulse = false;
                _rigidbody.isKinematic = true;
            }
        }

        public void SetImpulse(Vector3 direction, float impulsPower, float impulstime)
        {
            _rigidbody.isKinematic = false;

            _direction = direction;
            _impulsPower = impulsPower;
            _timer = impulstime;
        }

        public void Reset()
        {
            _rigidbody.isKinematic = true;
            _timer = 0;
        }
    }
}