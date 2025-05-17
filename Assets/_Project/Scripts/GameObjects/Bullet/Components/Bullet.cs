using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Bullet
    {
        public interface IAction
        {
            void Invoke(IEntity entity);
        }

        public event Action<Entity> OnDispose;

        private readonly List<IAction> _actions;
        private readonly EnviromentHitEffectComponent _enviromentHit;
        private readonly Entity _entity;

        public Bullet(List<IAction> actions, EnviromentHitEffectComponent enviromentHit, Entity entity)
        {
            _actions = actions;
            _enviromentHit = enviromentHit;
            _entity = entity;
        }

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

            if (_entity.TryGet<BulletProjectileMoveComponent>(out var component))
                component.Initialized = false;
        }
    }
}