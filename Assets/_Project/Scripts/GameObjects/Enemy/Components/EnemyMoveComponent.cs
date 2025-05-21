using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyMoveComponent : IInitializable, IDisposable
    {
        public interface IAction
        {
            bool Condition();
            void Action();
        }

        private readonly NavMeshAgent _agent;
        private readonly EnemyConditions _conditions;
        private readonly List<IAction> _actions;

        public EnemyMoveComponent(NavMeshAgent agent, EnemyConditions conditions, List<IAction> actions)
        {
            _agent = agent;
            _conditions = conditions;
            _actions = actions;
        }

        public void MoveTo(Vector3 destination) => _agent.SetDestination(destination);

        public void Initialize() => _conditions.OnValueChanged += DoAction;

        public void Dispose() => _conditions.OnValueChanged -= DoAction;

        private void DoAction()
        {
            foreach (var action in _actions)
                if (action.Condition())
                    action.Action();
        }
    }
}