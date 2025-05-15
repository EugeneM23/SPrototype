using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyChargeState : IState
    {
        public interface IAction
        {
            void EnterActions();
            void ExitActions();
        }

        private const float InitialTimerValue = 2f;
        private const float RaycastThreshold = 0.5f;
        private const float ChargeDuration = 1f;
        private const float ChargeSpeed = 50f;
        private const int RotationSpeed = 5;
        private const float RotationDuration = 1.5f;

        private readonly List<IAction> _actions;
        private readonly EnemyBlackBoard _blackBoard;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly TranslateComponent _translateComponent;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly ChargeRaySensor _chargeRaySensor;
        private readonly DelayedAction _delayedAction;

        private float _timer;
        private bool _isChargeCompleted;
        private Vector3 _chargeTargetPosition;

        public EnemyChargeState(
            EnemyBlackBoard blackBoard,
            NavMeshAgent navMeshAgent,
            List<IAction> actions,
            TranslateComponent translateComponent,
            EnemyAttackAssistComponent assistComponent,
            ChargeRaySensor chargeRaySensor,
            DelayedAction delayedAction)
        {
            _blackBoard = blackBoard;
            _navMeshAgent = navMeshAgent;
            _actions = actions;
            _translateComponent = translateComponent;
            _assistComponent = assistComponent;
            _chargeRaySensor = chargeRaySensor;
            _delayedAction = delayedAction;
        }

        public void OnEnter()
        {
            ExecuteActions(a => a.EnterActions());

            _blackBoard.IsBusy = true;
            _blackBoard.IsAttacking = true;
            _blackBoard.CanPush = false;

            _isChargeCompleted = false;
            _timer = InitialTimerValue;

            _navMeshAgent.enabled = false;

            _assistComponent.RotateToTarget(_blackBoard.Target, _blackBoard.Enemy, RotationSpeed, RotationDuration);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_timer > RaycastThreshold)
                _chargeTargetPosition = _chargeRaySensor.CastRay();

            _timer -= deltaTime;

            if (_timer <= 0f && !_isChargeCompleted)
                PerformCharge();
        }

        public void OnExit() => ResetState();

        private void PerformCharge()
        {
            _isChargeCompleted = true;
            _translateComponent.Translate(_chargeTargetPosition, ChargeDuration, ChargeSpeed);

            _delayedAction.Schedule(ChargeDuration, () => _blackBoard.IsBusy = false);

            ExecuteActions(a => a.ExitActions());
        }

        private void ResetState()
        {
            _timer = InitialTimerValue;
            _blackBoard.CanPush = true;
            _navMeshAgent.enabled = true;
            _blackBoard.IsBusy = false;

            ExecuteActions(a => a.ExitActions());
        }

        private void ExecuteActions(System.Action<IAction> action)
        {
            foreach (var a in _actions)
                action(a);
        }
    }
}