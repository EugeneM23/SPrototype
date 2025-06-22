using System.Collections.Generic;
using System.Linq;
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
        }
    }

    public class BulletSplashHitComponent : IBulletHIt
    {
        public interface ISplash
        {
            void Invoke(RaycastHit collider);
        }

        private readonly LayerMask _splashLayer = LayerMask.GetMask("Player");
        private readonly Entity _bullet;
        private readonly List<ISplash> _actions;
        private Transform _target;

        public BulletSplashHitComponent(Entity bullet, List<ISplash> actions)
        {
            _bullet = bullet;
            _actions = actions;
        }

        public void OnHit(RaycastHit collider)
        {
            _actions.ForEach(action => action.Invoke(collider));
            PerformSphereCast();
        }

        void PerformSphereCast()
        {
            if (Physics.CheckSphere(_bullet.transform.position, 5f, _splashLayer))
            {
                Collider[] hitCollider = Physics.OverlapSphere(_bullet.transform.position, 5f, _splashLayer);

                if (hitCollider.Length > 0)
                {
                    foreach (var item in hitCollider)
                    {
                        Debug.Log(item.gameObject.name);
                        if (item.transform.TryGetComponent(out Entity entity))
                        {
                            if (entity.TryGet(out HealthComponent healthComponent))
                                healthComponent.TakeDamage(100);

                            if (entity.TryGet(out PlayerImpulseComponent impulseComponent))
                            {
                                Vector3 direction =
                                    (entity.transform.position - _bullet.transform.position)
                                    .normalized;

                                impulseComponent.ApplyImpulse(direction * 70, 0.1f);
                                healthComponent.TakeDamage(100);
                            }
                        }
                    }

                    return;
                }
            }

            _target = null;
        }
    }

    public interface IBulletHIt
    {
        void OnHit(RaycastHit collider);
    }
}