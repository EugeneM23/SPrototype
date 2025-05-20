using System;

namespace Gameplay
{
    public class EnemyMelleDecision : EnemyDecisionBase
    {
        public override int Priority => 8;

        public EnemyMelleDecision(
            PlayerCharacterProvider provider,
            Entity entity,
            EnemyConditions conditions)
            : base(provider, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance) => distance < 2f;
        protected override Type GetTargetState() => typeof(EnemyMeleeAttackState);
    }
}