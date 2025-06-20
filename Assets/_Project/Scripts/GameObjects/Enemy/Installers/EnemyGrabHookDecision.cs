using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class EnemyGrabHookDecision : EnemyDecisionBase, ITickable
    {
        private bool _timerRunning = true;
        private float _timer;
        public override int Priority => 30;

        public EnemyGrabHookDecision(PlayerCharacterProvider playerCharacterProvider, Entity entity,
            CharacterConditions conditions) : base(playerCharacterProvider, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance > 10f && _timer < 0;
        }

        protected override Type GetTargetState()
        {
            _timer = 6f;
            return typeof(EnemyGrabHookState);
        }

        public void Tick()
        {
            if (_timerRunning)
            {
                _timer -= Time.deltaTime;
            }
        }
    }
}