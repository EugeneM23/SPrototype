using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class BulletHitComponent
    {
        public interface IEntiyCollisionAction
        {
            void Invoke(IEntity entity);
        }

        public interface IEnviromentCollisionAction
        {
            void Invoke(Collision collisionComponent);
        }

        private readonly List<IEntiyCollisionAction> _entityActions;
        private readonly List<IEnviromentCollisionAction> _enviromentActions;

        public BulletHitComponent(List<IEnviromentCollisionAction> enviromentActions,
            List<IEntiyCollisionAction> entityActions)
        {
            _enviromentActions = enviromentActions;
            _entityActions = entityActions;
        }

        public void OnHit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IEntity entity))
                _entityActions.ForEach(action => action.Invoke(entity));
            else
                _enviromentActions.ForEach(action => action.Invoke(collision));
        }
    }
}