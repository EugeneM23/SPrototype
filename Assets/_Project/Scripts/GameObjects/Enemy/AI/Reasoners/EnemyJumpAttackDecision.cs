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

        public EnemyJumpAttackDecision(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
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
            return _timer >= 3f;
        }

        protected override Type GetTargetState()
        {
            _timer = 0f;
            return typeof(EnemyJumpAttackState);
        }
    }
}