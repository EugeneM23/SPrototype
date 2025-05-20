using System;
using UnityEngine;

namespace Gameplay
{
    public class EnemyRangeDecision : EnemyDecisionBase
    {
        public override int Priority => 7;

        public EnemyRangeDecision(PlayerCharacterProvider provider,
            Entity entity, EnemyConditions conditions)
            : base(provider, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= 1f && distance < 15f;
        }

        protected override Type GetTargetState() => typeof(EnemyRangeAttackState);
    }
}