using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAirStikeDecision : EnemyDecisionBase, ITickable
    {
        private float _timer;
        private bool _timerRunning = true;

        public override int Priority => 11;

        public EnemyAirStikeDecision(PlayerCharacterProvider provider,
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
            return _conditions.IsRunning && _timer >= 7f;
        }

        protected override Type GetTargetState()
        {
            _timer = 0f;
            return typeof(EnemyAirStrikeState);
        }
    }
}