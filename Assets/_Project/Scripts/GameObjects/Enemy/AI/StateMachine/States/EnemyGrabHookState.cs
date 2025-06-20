using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Installers
{
    public class EnemyGrabHookState : IState
    {
        public interface IAction
        {
            void EnterActions();
            void ExitActions();
            void ExecuteActions();
        }

        private readonly float _initialTime;
        private readonly List<IAction> _actions;

        private float _timer;
        private bool _isChargeCompleted;

        public EnemyGrabHookState(List<IAction> actions, float initialTime)
        {
            _actions = actions;
            _initialTime = initialTime;
        }

        public void Update(float deltaTime)
        {
            _timer -= deltaTime;
            if (_timer <= 0f)
            {
                ExecuteActions(a => a.ExecuteActions());
                _isChargeCompleted = true;
            }
        }

        public void Enter()
        {
            Debug.Log("enter");
            ExecuteActions(a => a.EnterActions());
            _timer = _initialTime;
        }

        public void Exit()
        {
            ExecuteActions(a => a.ExitActions());
            _timer = _initialTime;
            _isChargeCompleted = false;
        }

        private void ExecuteActions(Action<IAction> action)
        {
            foreach (IAction a in _actions)
                action(a);
        }
    }
}