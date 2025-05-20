using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletRicochetAction
    {
        [Inject(Id = WeaponParameterID.MaxRicochetCount)]
        private int _maxRicochetCount;

        private readonly Transform _transform;
        private int _currentRicochetCount;

        public bool CanRicochet => _currentRicochetCount < _maxRicochetCount;

        public BulletRicochetAction(Transform transform)
        {
            _transform = transform;
        }

        public void Reset() => _currentRicochetCount = 0;

        public Vector3 Ricochet(Collision collision)
        {
            Vector3 newDirection = Vector3.Reflect(_transform.forward, collision.contacts[0].normal).normalized;
            _transform.forward = newDirection;

            _currentRicochetCount++;

            return newDirection;
        }
    }
}