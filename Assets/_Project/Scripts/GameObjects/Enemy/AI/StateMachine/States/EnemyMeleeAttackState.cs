using System;
using System.Collections.Generic;

namespace Gameplay
{
    public class EnemyMeleeAttackState : IState
    {
        public interface IAction
        {
            public void EnterAction();
            public void ExitAction();
        }

        private readonly List<IAction> _actions;
        private readonly DelayedAction _delayedAction;
        private readonly CharacterConditions _characterConditions;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly CharacterStats _stats;
        private readonly Enemy _enemy;

        private bool _isEnable;
        private float _fireRate;

        public EnemyMeleeAttackState(
            CharacterConditions characterConditions,
            EnemyAttackAssistComponent assistComponent,
            DelayedAction delayedAction,
            Enemy enemy,
            CharacterStats stats, List<IAction> actions)
        {
            _characterConditions = characterConditions;
            _assistComponent = assistComponent;
            _delayedAction = delayedAction;
            _enemy = enemy;
            _stats = stats;
            _actions = actions;
        }

        public void Enter()
        {
            ExecuteActions(a => a.EnterAction());
            _isEnable = true;
        }

        public void Exit()
        {
            ExecuteActions(a => a.ExitAction());
        }

        public void Update(float deltaTime)
        {
            if (_isEnable)
            {
                _characterConditions.IsBusy = true;
                _isEnable = false;

                _enemy.Shoot();

                _assistComponent.RotateToTarget(_stats.CharacterEntity.Get<TargetComponent>().Target,
                    _stats.CharacterEntity.transform, 10, 0.9f);

                _fireRate *= 1 - _stats.FireRateMultiplier / 100f;
                _delayedAction.Schedule(_fireRate, () => _characterConditions.IsBusy = false);
                _delayedAction.Schedule(_fireRate, () => _isEnable = true);
            }
        }

        public void SetFireRate(float fireRate)
        {
            _fireRate = fireRate;
        }

        private void ExecuteActions(Action<IAction> action)
        {
            foreach (IAction a in _actions)
                action(a);
        }
    }
}