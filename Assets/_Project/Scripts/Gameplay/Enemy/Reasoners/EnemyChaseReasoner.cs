using System;

namespace Gameplay
{
    public class EnemyChaseReasoner : EnemyReasonerBase
    {
        public override int Priority => 6;

        public EnemyChaseReasoner(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
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