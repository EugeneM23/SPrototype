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
            [Inject(Id = CharacterParameterID.CharacterEntity)]
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

    public class EnemyReloadState : IState
    {
        public void Enter()
        {
        }

        public void Update(float deltaTime)
        {
        }

        public void Exit()
        {
        }
    }
}