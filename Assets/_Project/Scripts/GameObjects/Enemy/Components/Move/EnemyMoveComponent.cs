using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyMoveComponent : IInitializable, IDisposable, IMove
    {
        public interface IAction
        {
            bool Condition();
            void Action();
        }

        private float _enemySpeed;

        private readonly CharacterStats _stats;
        private readonly NavMeshAgent _agent;
        private readonly CharacterConditions _conditions;
        private readonly List<IAction> _actions;

        public EnemyMoveComponent(NavMeshAgent agent, CharacterConditions conditions, List<IAction> actions,
            CharacterStats stats)
        {
            _agent = agent;
            _conditions = conditions;
            _actions = actions;
            _stats = stats;
            _enemySpeed = _stats.PatrolSpeed;
        }

        public void Move(Vector3 destination)
        {
            Debug.Log(_conditions.IsAlive);
            if (!_conditions.IsAlive || !_agent.enabled) return;
            _agent.SetDestination(destination);
            _agent.speed = _enemySpeed;
        }

        public void AddSpeed(float speed) => _enemySpeed += speed;

        public void Initialize() => _conditions.OnValueChanged += DoAction;

        public void Dispose() => _conditions.OnValueChanged -= DoAction;

        private void DoAction()
        {
            foreach (var action in _actions)
                if (action.Condition())
                    action.Action();
        }
    }

    public interface IMove
    {
        void Move(Vector3 destination);
    }
}