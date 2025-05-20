using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CollisionComponent : MonoBehaviour
    {
        public interface IEntiyCollisionAction
        {
            void Invoke(IEntity entity);
        }

        public interface IEnviromentCollisionAction
        {
            void Invoke(Collision collision);
        }

        [Inject] private readonly List<IEntiyCollisionAction> _entityActions = new();
        [Inject] private readonly List<IEnviromentCollisionAction> _enviromentActions = new();

        public event Action<Collision> OnCollision;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IEntity entity))
                _entityActions.ForEach(action => action.Invoke(entity));
            else
                _enviromentActions.ForEach(action => action.Invoke(collision));

            OnCollision?.Invoke(collision);
        }
    }
}