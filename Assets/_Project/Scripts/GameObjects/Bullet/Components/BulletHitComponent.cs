using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class BulletHitComponent
    {
        private readonly Entity _bullet;

        public interface IEntiyCollisionAction
        {
            void Invoke(IEntity entity);
        }

        public interface IEnviromentCollisionAction
        {
            void Invoke(RaycastHit hit);
        }

        private readonly List<IEntiyCollisionAction> _entityActions;
        private readonly List<IEnviromentCollisionAction> _enviromentActions;

        public BulletHitComponent(List<IEnviromentCollisionAction> enviromentActions,
            List<IEntiyCollisionAction> entityActions, Entity bullet)
        {
            _enviromentActions = enviromentActions;
            _entityActions = entityActions;
            _bullet = bullet;
        }

        public void OnHit(RaycastHit collider)
        {
            if (collider.collider.gameObject.TryGetComponent(out IEntity entity))
            {
                _entityActions.ForEach(action => action.Invoke(entity));
            }
            else
            {
                _enviromentActions.ForEach(action => action.Invoke(collider));
            }

            _bullet.Dispose();
        }
    }
}