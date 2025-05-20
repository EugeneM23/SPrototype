using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyJumpAttackDecision : EnemyDecisionBase, ITickable
    {
        private float _timer;
        private bool _timerRunning = true;

        public override int Priority => 15;

        public EnemyJumpAttackDecision(PlayerCharacterProvider provider,
            Entity entity, EnemyConditions conditions)
            : base(provider, entity, conditions)
        {
        }

        public void Tick()
        {
            if (_timerRunning && _conditions.IsRunning)
                _timer += Time.deltaTime;
        }

        protected override bool IsOnCondition(float distance)
        {
            return _timer >= 3f;
        }

        protected override Type GetTargetState()
        {
            _timer = 0f;
            return typeof(EnemyJumpAttackState);
        }
    }
}