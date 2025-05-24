using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyRangeAttackState : IState
    {
        public event Action OnEnter;
        public event Action OnExit;

        private readonly CharacterConditions _characterConditions;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly DelayedAction _delayedAction;
        private readonly Enemy _enemy;

        private readonly Entity _entity;

        private float _fireRate = 1;
        private float _timer;

        public EnemyRangeAttackState(
            CharacterConditions characterConditions,
            EnemyAttackAssistComponent assistComponent,
            DelayedAction delayedAction, Enemy enemy,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity entity
        )
        {
            _characterConditions = characterConditions;
            _assistComponent = assistComponent;
            _delayedAction = delayedAction;
            _enemy = enemy;
            _entity = entity;
        }

        public void Enter()
        {
            OnEnter?.Invoke();
            _characterConditions.IsBusy = true;
        }

        public void Update(float deltaTime)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _enemy.Shoot();
                _delayedAction.Schedule(_fireRate - 0.1f, () => _characterConditions.IsBusy = false);
                _assistComponent.RotateToTarget(_entity.Get<TargetComponent>().Target, _entity.transform, 10,
                    _fireRate);
                _timer = _fireRate;
            }
        }

        public void Exit()
        {
            OnExit?.Invoke();
            _characterConditions.IsBusy = false;
        }

        public void SetFireRate(float fireRate) => _fireRate = fireRate;
    }
}