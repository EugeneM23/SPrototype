using System;

namespace Gameplay
{
    public class EnemyMelleReasoner : EnemyReasonerBase
    {
        public override int Priority => 8;

        public EnemyMelleReasoner(
            PlayerCharacterProvider provider,
            EnemyStateMachine stateMachine,
            Entity entity,
            EnemyBlackBoard blackboard)
            : base(provider, stateMachine, entity, blackboard)
        {
        }

        protected override bool IsOnCondition(float distance) => distance < 2f;
        protected override Type GetTargetState() => typeof(EnemyMeleeAttackState);
    }
}