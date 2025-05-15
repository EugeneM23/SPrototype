using System;

namespace Gameplay
{
    public class EnemyRetreatReasoner : EnemyReasonerBase
    {
        public override int Priority => 11;

        public EnemyRetreatReasoner(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
            Entity entity, EnemyBlackBoard blackboard)
            : base(provider, stateMachine, entity, blackboard)
        {
        }

        protected override bool IsOnCondition(float distance) => distance < 6f;
        protected override Type GetTargetState() => typeof(EnemyRetreatState);
    }
}