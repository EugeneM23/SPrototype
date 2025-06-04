using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyMeleeAttackState : IState
    {
        private readonly DelayedAction _delayedAction;
        private readonly CharacterConditions _characterConditions;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly CharacterStats _stats;
        private readonly Enemy _enemy;

        private bool _isEnable;

        public EnemyMeleeAttackState(
            CharacterConditions characterConditions,
            EnemyAttackAssistComponent assistComponent,
            DelayedAction delayedAction,
            Enemy enemy,
            CharacterStats stats)
        {
            _characterConditions = characterConditions;
            _assistComponent = assistComponent;
            _delayedAction = delayedAction;
            _enemy = enemy;
            _stats = stats;
        }

        public void Enter()
        {
            _isEnable = true;
        }

        public void Exit()
        {
        }

        public void Update(float deltaTime)
        {
            if (_isEnable)
            {
                _characterConditions.IsBusy = true;
                _isEnable = false;

                _enemy.Shoot();

                _assistComponent.RotateToTarget(_stats.CharacterEntity.Get<TargetComponent>().Target,
                    _stats.CharacterEntity.transform, 10, 0.7f);

                var fireRate = _stats.CharacterEntity.Get<EnemyWeaponManager>().CurrentWeapon
                    .Get<WeaponCooldownAction>().FireRate;

                fireRate *= 1 - _stats.FireRateMultupleyer / 100f;
                _delayedAction.Schedule(fireRate, () => _characterConditions.IsBusy = false);
                _delayedAction.Schedule(fireRate, () => _isEnable = true);
            }
        }
    }
}