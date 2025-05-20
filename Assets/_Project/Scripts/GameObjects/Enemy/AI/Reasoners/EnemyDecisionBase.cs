using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public abstract class EnemyDecisionBase : IEnemyDecision, IInitializable
    {
        protected readonly Entity _entity;
        protected readonly PlayerCharacterProvider PlayerCharacterProvider;
        protected readonly EnemyConditions _conditions;

        public abstract int Priority { get; }

        protected EnemyDecisionBase(PlayerCharacterProvider playerCharacterProvider,
            Entity entity, EnemyConditions conditions)
        {
            PlayerCharacterProvider = playerCharacterProvider;
            _entity = entity;
            _conditions = conditions;
        }

        public virtual void Initialize()
        {
        }

        public bool IsValid()
        {
            float distance = DistanceToTarget();
            return IsOnCondition(distance);
        }

        public Type GetState()
        {
            if (_conditions.IsBusy) return null;

            return GetTargetState();
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