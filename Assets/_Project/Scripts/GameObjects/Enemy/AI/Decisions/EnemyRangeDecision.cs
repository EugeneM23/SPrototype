using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyRangeDecision : EnemyDecisionBase
    {
        private readonly int _range;
        public override int Priority => 7;

        public EnemyRangeDecision(
            PlayerCharacterProvider provider,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity entity,
            CharacterConditions conditions,
            int range)
            : base(provider, entity, conditions)
        {
            _range = range;
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= 1f && distance < _range;
        }

        protected override Type GetTargetState() => typeof(EnemyRangeAttackState);
    }
}