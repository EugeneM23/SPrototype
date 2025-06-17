using System;
using Zenject;

namespace Gameplay
{
    public class EnemyReloadDecision : EnemyDecisionBase
    {
        public override int Priority => 30;

        public EnemyReloadDecision(PlayerCharacterProvider provider,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity entity, CharacterConditions conditions)
            : base(provider, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return _conditions.IsReloaded;
        }

        protected override Type GetTargetState() => typeof(EnemyReloadState);
    }
}