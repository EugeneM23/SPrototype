using System;
using UnityEngine;

namespace Gameplay
{
    public class EnemyRangeReasoner : EnemyReasonerBase
    {
        public override int Priority => 7;

        public EnemyRangeReasoner(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
            Entity entity, EnemyBlackBoard blackboard)
            : base(provider, stateMachine, entity, blackboard)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= 2f && distance < 8f;
        }

        protected override Type GetTargetState() => typeof(EnemyRangeAttackState);
    }
}