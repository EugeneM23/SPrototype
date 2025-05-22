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
        private readonly CharacterConditions _characterConditions;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly Enemy _enemy;

        private readonly Entity _entity;

        private bool _isEnable;

        public EnemyMeleeAttackState(
            CharacterConditions characterConditions,
            EnemyAttackAssistComponent assistComponent,
            DelayedAction attackSwitcher,
            Enemy enemy,
            Entity entity
        )
        {
            _characterConditions = characterConditions;
            _assistComponent = assistComponent;
            _attackSwitcher = attackSwitcher;
            _enemy = enemy;
            _entity = entity;
        }

        public void Enter()
        {
            _characterConditions.IsBusy = true;
            _isEnable = true;
        }

        public void Exit()
        {
            _characterConditions.IsBusy = false;
        }

        public void Update(float deltaTime)
        {
            if (_isEnable)
            {
                _isEnable = false;
                _enemy.Shoot();
                _assistComponent.RotateToTarget(_entity.Get<TargetComponent>().Target, _entity.transform, 10, 0.7f);
                _attackSwitcher.Schedule(1f, () => _characterConditions.IsBusy = false);
            }
        }
    }
}