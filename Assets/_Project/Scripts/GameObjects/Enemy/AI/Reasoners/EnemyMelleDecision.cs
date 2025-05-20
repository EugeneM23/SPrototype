using System;

namespace Gameplay
{
    public class EnemyMelleDecision : EnemyDecisionBase
    {
        public override int Priority => 8;

        public EnemyMelleDecision(
            PlayerCharacterProvider provider,
            EnemyStateMachine stateMachine,
            Entity entity,
            EnemyConditions conditions)
            : base(provider, stateMachine, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance) => distance < 2f;
        protected override Type GetTargetState() => typeof(EnemyMeleeAttackState);
    }
}