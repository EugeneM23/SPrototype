using UnityEngine;
using Zenject;

namespace Gameplay
{
    internal class PushableObjectController : IInitializable
    {
        private readonly PushComponent _pushComponent;
        private readonly CollisionComponent _collisionComponent;
        private readonly EnemyConditions _blackboard;

        public PushableObjectController(PushComponent pushComponent, EnemyConditions blackboard)
        {
            _pushComponent = pushComponent;
            _blackboard = blackboard;
        }

        public void SetImpulse(Vector3 direction, float impulsPower, float impulstime)
        {
            if (_blackboard.CanPush)
                _pushComponent.SetImpulse(direction, impulsPower, impulstime);
        }

        public void Initialize()
        {
            _blackboard.CanPush = true;
        }
    }
}