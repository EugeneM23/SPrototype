using System;

namespace Gameplay
{
    public class EnemyChaseDecision : EnemyDecisionBase
    {
        public override int Priority => 6;

        public EnemyChaseDecision(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
            Entity entity, EnemyBlackBoard blackboard)
            : base(provider, stateMachine, entity, blackboard)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= 2f && distance < _blackboard.ChaseRange;
        }

        protected override Type GetTargetState() => typeof(EnemyChaseState);
    }
}