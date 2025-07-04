using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

namespace Gameplay
{
    public class BulletCollisionComponent : ITickable
    {
        private readonly Entity _bullet;
        private readonly IBulletHIt _bulletHitComponent;

        private Vector3 _previousPosition;
        public LayerMask CollisionLayer { get; private set; }

        public BulletCollisionComponent(Entity bullet, IBulletHIt bulletHitComponent)
        {
            _bullet = bullet;
            _bulletHitComponent = bulletHitComponent;
            _previousPosition = _bullet.transform.position;
        }

        public void CheckCollision()
        {
            Debug.Log(CollisionLayer.value);
            Vector3 currentPosition = _bullet.transform.position;
            Vector3 direction = currentPosition - _previousPosition;

            float distance = direction.magnitude;
            if (distance > 0 && Physics.Raycast(_previousPosition, direction.normalized, out RaycastHit hit, distance,
                    CollisionLayer))

            {
                _bulletHitComponent.OnHit(hit);
                _bullet.Dispose();
            }


            _previousPosition = currentPosition;
        }

        public void Tick() => CheckCollision();

        public void SetCollisionLayer(LayerMask layer) => CollisionLayer = layer;

        public void ResetRaycastPosition(Vector3 position) => _previousPosition = position;
    }
}