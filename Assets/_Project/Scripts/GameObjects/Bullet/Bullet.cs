using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Bullet : IInitializable, IDisposable
    {
        public event Action<Entity> OnDispose;

        private readonly Entity _entity;
        private readonly CollisionComponent _collisionComponent;

        public Bullet(Entity entity, CollisionComponent collisionComponent)
        {
            _entity = entity;
            _collisionComponent = collisionComponent;
        }

        public void Initialize() => _collisionComponent.OnCollision += Hit;

        public void Hit(Collision collision) => Dispose();

        public void Dispose()
        {
            OnDispose?.Invoke(_entity);
            _collisionComponent.OnCollision -= Hit;

            if (_entity.TryGet<BulletProjectileMoveComponent>(out var component))
                component.Initialized = false;
        }
    }
}