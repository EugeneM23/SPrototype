using System;

namespace Gameplay
{
    public class EnemyRetreatDecision : EnemyDecisionBase
    {
        public override int Priority => 11;

        public EnemyRetreatDecision(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
            Entity entity, EnemyBlackBoard blackboard)
            : base(provider, stateMachine, entity, blackboard)
        {
        }

        protected override bool IsOnCondition(float distance) => distance < 6f;
        protected override Type GetTargetState() => typeof(EnemyRetreatState);
    }
}