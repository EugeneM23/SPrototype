using System;

namespace Gameplay
{
    public class EnemyRetreatDecision : EnemyDecisionBase
    {
        public override int Priority => 11;

        public EnemyRetreatDecision(PlayerCharacterProvider provider, 
            Entity entity, EnemyConditions conditions)
            : base(provider, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance) => distance < 6f;
        protected override Type GetTargetState() => typeof(EnemyRetreatState);
    }
}