using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyStateMachine : ITickable
    {
        private readonly Dictionary<Type, IState> _states;
        private readonly List<IEnemyDecision> _decisions;

        private IState _currentState;
        private IEnemyDecision _currentDecision;

        private readonly CharacterConditions _conditions;

        public EnemyStateMachine(List<IState> states, List<IEnemyDecision> decisions, CharacterConditions conditions)
        {
            _decisions = decisions;
            _conditions = conditions;
            _states = states.ToDictionary(state => state.GetType(), state => state);
            _currentDecision = _decisions[0];
        }

        public void Tick()
        {
            if (!_conditions.IsAlive) return;

            EvaluateDecisions();
            _currentState?.Update(Time.deltaTime);
        }

        public void SetState(Type state)
        {
            Debug.Log("SetState: " + state);
            if (_currentState?.GetType() == state || state == null) return;

            _currentState?.Exit();
            _currentState = _states[state];
            _currentState?.Enter();
        }

        private void EvaluateDecisions()
        {
            if (_decisions == null) return;

            IEnemyDecision bestDecision = _currentDecision;
            int highestPriority = int.MinValue;

            foreach (var reasoner in _decisions)
            {
                if (reasoner.IsValid() && reasoner.Priority > highestPriority)
                {
                    bestDecision = reasoner;
                    highestPriority = reasoner.Priority;
                }
            }

            _currentDecision = bestDecision;
            SetState(_currentDecision.GetState());
        }
    }
}