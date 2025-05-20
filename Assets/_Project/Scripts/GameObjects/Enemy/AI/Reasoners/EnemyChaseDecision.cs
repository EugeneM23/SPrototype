using System;
using Zenject;

namespace Gameplay
{
    public class EnemyChaseDecision : EnemyDecisionBase
    {
        [Inject(Id = EnemyParameterID.ChaseRange)]
        private readonly float _chaseRange;
        public override int Priority => 6;

        public EnemyChaseDecision(PlayerCharacterProvider provider, EnemyStateMachine stateMachine,
            Entity entity, EnemyConditions conditions)
            : base(provider, stateMachine, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= 2f && distance < _chaseRange;
        }

        protected override Type GetTargetState() => typeof(EnemyChaseState);
    }
}