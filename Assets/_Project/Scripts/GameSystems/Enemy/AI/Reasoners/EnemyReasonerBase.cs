using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public abstract class EnemyReasonerBase : IEnemyReasoner, IInitializable
    {
        protected readonly Entity _entity;
        protected readonly EnemyStateMachine _stateMachine;
        protected readonly PlayerCharacterProvider PlayerCharacterProvider;
        protected readonly EnemyBlackBoard _blackboard;

        public abstract int Priority { get; }

        protected EnemyReasonerBase(PlayerCharacterProvider playerCharacterProvider, EnemyStateMachine stateMachine,
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

        public bool CanReason()
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
            return Vector3.Distance(PlayerCharacterProvider.Character.transform.position, _entity.transform.position);
        }

        protected abstract bool IsOnCondition(float distance);
        protected abstract Type GetTargetState();
    }
}