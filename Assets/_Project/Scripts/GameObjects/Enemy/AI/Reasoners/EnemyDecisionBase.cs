using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public abstract class EnemyDecisionBase : IEnemyDecision, IInitializable
    {
        protected readonly Entity _entity;
        protected readonly EnemyStateMachine _stateMachine;
        protected readonly PlayerCharacterProvider PlayerCharacterProvider;
        protected readonly EnemyBlackBoard _blackboard;

        public abstract int Priority { get; }

        protected EnemyDecisionBase(PlayerCharacterProvider playerCharacterProvider, EnemyStateMachine stateMachine,
            Entity entity, EnemyBlackBoard blackboard)
        {
            PlayerCharacterProvider = playerCharacterProvider;
            _stateMachine = stateMachine;
            _entity = entity;
            _blackboard = blackboard;
        }

        public virtual void Initialize()
        {
            _blackboard.Target = PlayerCharacterProvider.Character;
        }

        public bool IsValid()
        {
            float distance = DistanceToTarget();
            return IsOnCondition(distance);
        }

        public void ApplyReasoning()
        {
            if (_blackboard.IsBusy) return;

            _stateMachine.SetState(GetTargetState());
        }

        protected float DistanceToTarget()
        {
            if (PlayerCharacterProvider.Character == null || _entity == null) return float.PositiveInfinity;
            return Vector3.Distance(PlayerCharacterProvider.Character.transform.position, _entity.transform.position);
        }

        protected abstract bool IsOnCondition(float distance);
        protected abstract Type GetTargetState();
    }
}