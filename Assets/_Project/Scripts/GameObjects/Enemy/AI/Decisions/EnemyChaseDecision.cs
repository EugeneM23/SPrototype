using System;
using Zenject;

namespace Gameplay
{
    public class EnemyChaseDecision : EnemyDecisionBase
    {
        [Inject(Id = CharacterParameterID.ChaseRange)]
        private readonly float _chaseRange;

        public override int Priority => 6;

        public EnemyChaseDecision(PlayerCharacterProvider provider,
            Entity entity, CharacterConditions conditions)
            : base(provider, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= 2f && distance < _chaseRange;
        }

        protected override Type GetTargetState() => typeof(EnemyChaseState);
    }
}