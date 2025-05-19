using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyRangeAttackState : IState
    {
        public event System.Action OnEnter;
        public event System.Action OnExit;

        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyBlackBoard _blackboard;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly DelayedAction _delayedAction;
        private readonly Enemy _enemy;

        private float _fireRate = 1;
        private float _timer;

        public EnemyRangeAttackState(
            NavMeshAgent navMeshAgent,
            EnemyBlackBoard blackboard,
            EnemyAttackAssistComponent assistComponent,
            DelayedAction delayedAction, Enemy enemy)
        {
            _navMeshAgent = navMeshAgent;
            _blackboard = blackboard;
            _assistComponent = assistComponent;
            _delayedAction = delayedAction;
            _enemy = enemy;
        }

        public void Enter()
        {
            OnEnter?.Invoke();
            _navMeshAgent.enabled = false;
            _blackboard.IsBusy = true;
        }

        public void Update(float deltaTime)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _enemy.Shoot();
                _delayedAction.Schedule(_fireRate - 0.1f, () => _blackboard.IsBusy = false);
                _assistComponent.RotateToTarget(_blackboard.Target, _blackboard.Enemy, 10, _fireRate);
                _timer = _fireRate;
            }
        }

        public void Exit()
        {
            OnExit?.Invoke();
            _navMeshAgent.enabled = true;
            _blackboard.IsBusy = false;
        }

        public void SetFireRate(float fireRate) => _fireRate = fireRate;
    }
}