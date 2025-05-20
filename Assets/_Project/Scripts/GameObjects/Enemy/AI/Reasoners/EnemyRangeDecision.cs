using System;
using UnityEngine;

namespace Gameplay
{
    public class EnemyRangeDecision : EnemyDecisionBase
    {
        public override int Priority => 7;

        public EnemyRangeDecision(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
            Entity entity, EnemyBlackBoard blackboard)
            : base(provider, stateMachine, entity, blackboard)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= 1f && distance < 15f;
        }

        protected override Type GetTargetState() => typeof(EnemyRangeAttackState);
    }
}