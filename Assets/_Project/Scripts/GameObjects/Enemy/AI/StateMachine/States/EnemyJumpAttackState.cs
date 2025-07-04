using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyJumpAttackState : IState
    {
        private const float InitialTimerValue = 3f;
        private const float JumpDuration = 1f;
        private const float JumpSpeed = 10f;
        private const int RotationSpeed = 5;
        private const float RotationDuration = 1.5f;

        private readonly CharacterConditions _conditions;
        private readonly TranslateComponent _translateComponent;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly Animator _animator;
        private readonly DelayedAction _delayedAction;
        private readonly TargetComponent _targetComponent;
        private readonly Entity _entity;

        private float _timer;
        private bool _isCompleted;
        private Vector3 _jumpTargetPosition;

        public EnemyJumpAttackState(
            CharacterConditions conditions,
            TranslateComponent translateComponent,
            EnemyAttackAssistComponent assistComponent,
            Animator animator,
            TargetComponent targetComponent,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity entity, DelayedAction delayedAction)
        {
            _conditions = conditions;
            _translateComponent = translateComponent;
            _assistComponent = assistComponent;
            _animator = animator;
            _targetComponent = targetComponent;
            _entity = entity;
            _delayedAction = delayedAction;
        }

        public void Enter()
        {
            _conditions.IsBusy = true;

            _isCompleted = false;
            _timer = InitialTimerValue;

            _jumpTargetPosition = _targetComponent.Target.transform.position;

            _animator.Play("JumpAttack");
            _assistComponent.RotateToTarget(_targetComponent.Target, _entity.transform, RotationSpeed,
                RotationDuration);
            _delayedAction.Schedule(0.4f, () => _translateComponent.Translate(_jumpTargetPosition, JumpDuration,
                JumpSpeed, 0,
                _targetComponent.Target.transform));
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
            _conditions.IsBusy = false;
        }
    }
}