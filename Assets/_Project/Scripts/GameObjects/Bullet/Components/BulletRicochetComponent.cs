using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletRicochetComponent
    {
        private readonly WeaponSetings _setings;
        private readonly Transform _transform;
        private int _currentRicochetCount;

        public bool CanRicochet => _currentRicochetCount < _setings.MaxRicochetCount;

        public BulletRicochetComponent( Transform transform, WeaponSetings setings)
        {
            _transform = transform;
            _setings = setings;
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