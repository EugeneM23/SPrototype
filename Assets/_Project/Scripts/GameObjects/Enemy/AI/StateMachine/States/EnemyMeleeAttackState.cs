using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyMeleeAttackState : IState
    {
        private readonly DelayedAction _attackSwitcher;
        private readonly EnemyBlackBoard _blackboard;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly Enemy _enemy;

        private float _timer;
        private bool _isEnable;

        public EnemyMeleeAttackState(
            EnemyBlackBoard blackboard,
            EnemyAttackAssistComponent assistComponent,
            DelayedAction attackSwitcher,
            NavMeshAgent navMeshAgent,
            Enemy enemy)
        {
            _blackboard = blackboard;
            _assistComponent = assistComponent;
            _attackSwitcher = attackSwitcher;
            _navMeshAgent = navMeshAgent;
            _enemy = enemy;
        }

        public void Enter()
        {
            Debug.Log("sdasda");

            _navMeshAgent.enabled = false;
            SetBlackboardState(isBusy: true, isAttacking: true);
            _timer = 0.7f;
            _isEnable = true;
        }

        public void Exit()
        {
            _navMeshAgent.enabled = true;
            SetBlackboardState(isBusy: false, isAttacking: false);
        }

        public void Update(float deltaTime)
        {
            if (_isEnable)
            {
                _isEnable = false;
                _enemy.Shoot();
                _assistComponent.RotateToTarget(_blackboard.Target, _blackboard.Enemy, 10, 0.7f);
                _attackSwitcher.Schedule(0.7f, () => _blackboard.IsBusy = false);
            }
        }

        private void SetBlackboardState(bool isBusy, bool isAttacking)
        {
            _blackboard.IsBusy = isBusy;
            _blackboard.IsAttacking = isAttacking;
        }
    }
}