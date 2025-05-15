using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyChargeAttackReasoner : EnemyReasonerBase, ITickable
    {
        private float _timer;
        private bool _timerRunning = true;

        public override int Priority => 12;

        public EnemyChargeAttackReasoner(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
            Entity entity, EnemyBlackBoard blackboard)
            : base(provider, stateMachine, entity, blackboard)
        {
        }

        public void Tick()
        {
            if (_timerRunning && _blackboard.IsRunning)
                _timer += Time.deltaTime;
        }

        protected override bool IsOnCondition(float distance)
        {
            return _blackboard.IsRunning && _timer >= 3f;
        }

        protected override Type GetTargetState()
        {
            _timer = 0f;
            return typeof(EnemyChargeState);
        }
    }
}