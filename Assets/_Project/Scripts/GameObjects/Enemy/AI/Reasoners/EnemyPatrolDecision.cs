using System;
using Zenject;

namespace Gameplay
{
    public class EnemyPatrolDecision : EnemyDecisionBase
    {
        [Inject(Id = EnemyParameterID.ChaseRange)]
        private readonly float _chaseRange;
        public override int Priority => 2;

        public EnemyPatrolDecision(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
            Entity entity, EnemyConditions conditions)
            : base(provider, stateMachine, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= _chaseRange;
        }

        protected override Type GetTargetState() => typeof(EnemyPatrolState);
    }
}