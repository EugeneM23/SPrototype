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

        private readonly EnemyBlackBoard _blackBoard;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly TranslateComponent _translateComponent;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly Animator _animator;

        private float _timer;
        private bool _isCompleted;
        private Vector3 _jumpTargetPosition;

        public EnemyJumpAttackState(
            EnemyBlackBoard blackBoard,
            NavMeshAgent navMeshAgent,
            TranslateComponent translateComponent,
            EnemyAttackAssistComponent assistComponent,
            Animator animator)
        {
            _blackBoard = blackBoard;
            _navMeshAgent = navMeshAgent;
            _translateComponent = translateComponent;
            _assistComponent = assistComponent;
            _animator = animator;
        }

        public void OnEnter()
        {
            _blackBoard.IsBusy = true;
            _blackBoard.IsAttacking = true;
            _blackBoard.CanPush = false;

            _isCompleted = false;
            _timer = InitialTimerValue;
            _navMeshAgent.enabled = false;

            _jumpTargetPosition = _blackBoard.Target.transform.position;

            _animator.Play("JumpAttack");
            _assistComponent.RotateToTarget(_blackBoard.Target, _blackBoard.Enemy, RotationSpeed, RotationDuration);
            _translateComponent.Translate(_jumpTargetPosition, JumpDuration, JumpSpeed, 0,
                _blackBoard.Target.transform);
        }

        public void OnUpdate(float deltaTime)
        {
            _timer -= deltaTime;

            if (_timer <= 0f && !_isCompleted)
            {
                _isCompleted = true;
                _blackBoard.IsBusy = false;
            }
        }

        public void OnExit()
        {
            _timer = InitialTimerValue;
            _blackBoard.CanPush = true;
            _blackBoard.IsBusy = false;
            _navMeshAgent.enabled = true;
        }
    }
}