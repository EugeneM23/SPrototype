using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class BulletHitComponent : IBulletHIt
    {
        private readonly Entity _bullet;

        public interface IEntiyCollisionAction
        {
            void Invoke(RaycastHit collider);
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
                _entityActions.ForEach(action => action.Invoke(collider));
            }
            else
            {
                _enviromentActions.ForEach(action => action.Invoke(collider));
            }

            _bullet.Dispose();
        }
    }

    public class BulletSplashHitComponent : IBulletHIt
    {
        public interface ISplash
        {
            void Invoke(RaycastHit collider);
        }

        private readonly Entity _bullet;
        private readonly List<ISplash> _actions;

        public BulletSplashHitComponent(Entity bullet, List<ISplash> actions)
        {
            _bullet = bullet;
            _actions = actions;
        }

        public void OnHit(RaycastHit collider)
        {
            _actions.ForEach(action => action.Invoke(collider));
            _bullet.Dispose();
        }
    }

    public interface IBulletHIt
    {
        void OnHit(RaycastHit collider);
    }
}