using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyRangeAttackState : IState
    {
        public event Action OnEnter;
        public event Action OnExit;

        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyConditions _blackboard;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly DelayedAction _delayedAction;
        private readonly Enemy _enemy;

        
        private readonly TargetComponent _targetComponent;
        private readonly Entity _entity;
        
        private float _fireRate = 1;
        private float _timer;

        public EnemyRangeAttackState(
            NavMeshAgent navMeshAgent,
            EnemyConditions blackboard,
            EnemyAttackAssistComponent assistComponent,
            DelayedAction delayedAction, Enemy enemy, TargetComponent targetComponent, Entity entity)
        {
            _navMeshAgent = navMeshAgent;
            _blackboard = blackboard;
            _assistComponent = assistComponent;
            _delayedAction = delayedAction;
            _enemy = enemy;
            _targetComponent = targetComponent;
            _entity = entity;
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
                _assistComponent.RotateToTarget(_targetComponent.Target, _entity.transform, 10, _fireRate);
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