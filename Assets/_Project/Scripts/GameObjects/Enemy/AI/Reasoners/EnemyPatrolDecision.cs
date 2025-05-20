using System;

namespace Gameplay
{
    public class EnemyPatrolDecision : EnemyDecisionBase
    {
        public override int Priority => 2;

        public EnemyPatrolDecision(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
            Entity entity, EnemyBlackBoard blackboard)
            : base(provider, stateMachine, entity, blackboard)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= _blackboard.ChaseRange;
        }

        protected override Type GetTargetState() => typeof(EnemyPatrolState);
    }
}