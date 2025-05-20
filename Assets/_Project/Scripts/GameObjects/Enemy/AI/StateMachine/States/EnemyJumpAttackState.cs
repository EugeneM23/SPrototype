using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyJumpAttackState : IState
    {
        private const float InitialTimerValue = 2f;
        private const float JumpDuration = 1f;
        private const float JumpSpeed = 10f;
        private const int RotationSpeed = 5;
        private const float RotationDuration = 1.5f;

        private readonly EnemyConditions _conditions;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly TranslateComponent _translateComponent;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly Animator _animator;

        private readonly TargetComponent _targetComponent;
        private readonly Entity _entity;
        
        private float _timer;
        private bool _isCompleted;
        private Vector3 _jumpTargetPosition;

        public EnemyJumpAttackState(
            EnemyConditions conditions,
            NavMeshAgent navMeshAgent,
            TranslateComponent translateComponent,
            EnemyAttackAssistComponent assistComponent,
            Animator animator, TargetComponent targetComponent, Entity entity)
        {
            _conditions = conditions;
            _navMeshAgent = navMeshAgent;
            _translateComponent = translateComponent;
            _assistComponent = assistComponent;
            _animator = animator;
            _targetComponent = targetComponent;
            _entity = entity;
        }

        public void Enter()
        {
            _conditions.IsBusy = true;
            _conditions.IsAttacking = true;
            _conditions.CanPush = false;

            _isCompleted = false;
            _timer = InitialTimerValue;
            _navMeshAgent.enabled = false;

            _jumpTargetPosition = _targetComponent.Target.transform.position;

            _animator.Play("JumpAttack");
            _assistComponent.RotateToTarget(_targetComponent.Target, _entity.transform, RotationSpeed, RotationDuration);
            _translateComponent.Translate(_jumpTargetPosition, JumpDuration, JumpSpeed, 0,
                _targetComponent.Target.transform);
        }

        public void Update(float deltaTime)
        {
            _timer -= deltaTime;

            if (_timer <= 0f && !_isCompleted)
            {
                _isCompleted = true;
                _conditions.IsBusy = false;
            }
        }

        public void Exit()
        {
            _timer = InitialTimerValue;
            _conditions.CanPush = true;
            _conditions.IsBusy = false;
            _navMeshAgent.enabled = true;
        }
    }
}