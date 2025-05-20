using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyChargeAttackDecision : EnemyDecisionBase, ITickable
    {
        private float _timer;
        private bool _timerRunning = true;

        public override int Priority => 12;

        public EnemyChargeAttackDecision(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
            Entity entity, EnemyConditions conditions)
            : base(provider, stateMachine, entity, conditions)
        {
        }

        public void Tick()
        {
            if (_timerRunning && _conditions.IsRunning)
                _timer += Time.deltaTime;
        }

        protected override bool IsOnCondition(float distance)
        {
            return _conditions.IsRunning && _timer >= 3f;
        }

        protected override Type GetTargetState()
        {
            _timer = 0f;
            return typeof(EnemyChargeState);
        }
    }
}