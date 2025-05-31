using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyChaseState : IState
    {
        private readonly CharacterStats _stats;
        private EnemyMoveComponent _moveComponent;
        private readonly CharacterConditions _conditions;
        private readonly TargetComponent _targetComponent;
        private Transform _target;

        public EnemyChaseState(
            CharacterConditions conditions,
            TargetComponent targetComponent,
            EnemyMoveComponent moveComponent, CharacterStats stats)
        {
            _conditions = conditions;
            _targetComponent = targetComponent;
            _moveComponent = moveComponent;
            _stats = stats;
        }

        public void Enter()
        {
            _conditions.IsChasing = true;
            _moveComponent.AddSpeed(_stats.ChaseSpeed);
        }

        public void Update(float deltaTime)
        {
            _target = _targetComponent.Target;

            if (_target == null) return;

            _moveComponent.Move(_target.position);
        }

        public void Exit()
        {
            _conditions.IsChasing = false;
            _moveComponent.AddSpeed(-_stats.ChaseSpeed);
        }
    }
}