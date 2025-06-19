using System;
using Zenject;

namespace Gameplay
{
    public class EnemyMelleDecision : EnemyDecisionBase
    {
        public override int Priority => 8;

        public EnemyMelleDecision(
            PlayerCharacterProvider provider,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity entity,
            CharacterConditions conditions)
            : base(provider, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance) => distance < 5f;
        protected override Type GetTargetState() => typeof(EnemyMeleeAttackState);
    }
}