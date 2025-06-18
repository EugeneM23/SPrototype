using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletMoveComponent : IBulletMoveComponent
    {
        private float _bulletSpeed;

        private readonly Entity _bullet;

        public BulletMoveComponent(Entity bullet)
        {
            _bullet = bullet;
        }

        public void Move()
        {
            _bullet.transform.position += _bullet.transform.forward * Time.deltaTime * _bulletSpeed;
        }

        public void SetSeed(int seed) => _bulletSpeed = seed;
    }

    public class BulletCollisionComponent : ITickable
    {
        public event Action<RaycastHit> OnHit;

        private readonly BulletDamageAction _damageAction;
        private readonly Entity _bullet;

        private Vector3 _previousPosition;
        private LayerMask _layer;

        public BulletCollisionComponent(Entity bullet, BulletDamageAction damageAction)
        {
            _bullet = bullet;
            _damageAction = damageAction;
            _previousPosition = _bullet.transform.position;
        }

        public void CheckCollision()
        {
            Vector3 currentPosition = _bullet.transform.position;
            Vector3 direction = currentPosition - _previousPosition;

            float distance = direction.magnitude;
            if (distance > 0 && Physics.Raycast(_previousPosition, direction.normalized, out RaycastHit hit, distance,
                    _layer))

            {
                OnHit?.Invoke(hit);
                _bullet.Dispose();
            }


            _previousPosition = currentPosition;
        }

        public void Tick()
        {
            CheckCollision();
        }

        public void SetCollisionLayer(LayerMask layer)
        {
            _layer = layer;
        }
    }
}