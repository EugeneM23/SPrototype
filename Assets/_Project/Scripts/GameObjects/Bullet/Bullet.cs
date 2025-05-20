using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Bullet : IInitializable, IDisposable
    {
        public interface IAction
        {
            void Invoke(IEntity entity);
        }

        public event Action<Entity> OnDispose;

        private readonly List<IAction> _actions;
        private readonly EnviromentHitEffectComponent _enviromentHit;
        private readonly Entity _entity;
        private readonly CollisionComponent _collisionComponent;

        public Bullet(List<IAction> actions,
            EnviromentHitEffectComponent enviromentHit,
            Entity entity,
            CollisionComponent collisionComponent)
        {
            _actions = actions;
            _enviromentHit = enviromentHit;
            _entity = entity;
            _collisionComponent = collisionComponent;
        }

        public void Initialize() => _collisionComponent.OnCollision += Hit;

        public void Hit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IEntity entity))
                _actions.ForEach(action => action.Invoke(entity));
            else
                _enviromentHit.SpawnImpactEffect(collision);

            Dispose();
        }

        public void Dispose()
        {
            OnDispose?.Invoke(_entity);
            _collisionComponent.OnCollision -= Hit;

            if (_entity.TryGet<BulletProjectileMoveComponent>(out var component))
                component.Initialized = false;
        }
    }
}