using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyChaseDecision : EnemyDecisionBase
    {
        [Inject(Id = CharacterParameterID.ChaseRange)]
        private readonly float _chaseRange;

        public override int Priority => 6;

        public EnemyChaseDecision(PlayerCharacterProvider provider,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity entity, CharacterConditions conditions)
            : base(provider, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance >= 3f && distance < _chaseRange && !_conditions.IsBusy;
        }

        protected override Type GetTargetState() => typeof(EnemyChaseState);
    }

    public class EnemyKamikazeDecision : EnemyDecisionBase
    {
        private readonly float _kamikazeRange;

        public override int Priority => 20;

        public EnemyKamikazeDecision(PlayerCharacterProvider provider,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity entity, CharacterConditions conditions, float kamikazeRange)
            : base(provider, entity, conditions)
        {
            _kamikazeRange = kamikazeRange;
        }

        protected override bool IsOnCondition(float distance)
        {
            return distance < _kamikazeRange && !_conditions.IsBusy;
        }

        protected override Type GetTargetState() => typeof(EnemyKamikazeState);
    }
}