using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyStateMachine : ITickable
    {
        private IState _currentState;

        private readonly Dictionary<Type, IState> _states;

        public EnemyStateMachine(List<IState> states)
        {
            _states = states.ToDictionary(state => state.GetType(), state => state);
        }

        public void Tick()
        {
            _currentState?.OnUpdate(Time.deltaTime);
        }

        public void SetState<T>()
        {
            _currentState?.OnExit();
            _currentState = _states[typeof(T)];
            _currentState?.OnEnter();
        }

        public void SetState(Type getTargetState)
        {
            _currentState?.OnExit();
            _currentState = _states[getTargetState];
            _currentState?.OnEnter();
        }
    }
}