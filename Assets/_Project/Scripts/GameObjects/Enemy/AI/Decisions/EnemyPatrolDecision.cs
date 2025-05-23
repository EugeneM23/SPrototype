using System;
using Zenject;

namespace Gameplay
{
    public class EnemyPatrolDecision : EnemyDecisionBase
    {
        [Inject(Id = CharacterParameterID.ChaseRange)]
        private readonly float _chaseRange;

        public override int Priority => 2;

        public EnemyPatrolDecision(PlayerCharacterProvider provider,
            Entity entity, CharacterConditions conditions)
            : base(provider, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= _chaseRange;
        }

        protected override Type GetTargetState() => typeof(EnemyPatrolState);
    }
}