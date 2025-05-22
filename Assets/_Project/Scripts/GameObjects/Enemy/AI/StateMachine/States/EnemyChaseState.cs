using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyChaseState : IState
    {
        private EnemyMoveComponent _moveComponent;
        private readonly CharacterConditions _conditions;
        private readonly TargetComponent _targetComponent;
        private Transform _target;

        public EnemyChaseState(
            CharacterConditions conditions,
            TargetComponent targetComponent,
            EnemyMoveComponent moveComponent
        )
        {
            _conditions = conditions;
            _targetComponent = targetComponent;
            _moveComponent = moveComponent;
        }

        public void Enter() => _conditions.IsChasing = true;

        public void Update(float deltaTime)
        {
            _target = _targetComponent.Target;

            if (_target == null) return;

            _moveComponent.MoveTo(_target.position);
        }

        public void Exit() => _conditions.IsChasing = false;
    }
}