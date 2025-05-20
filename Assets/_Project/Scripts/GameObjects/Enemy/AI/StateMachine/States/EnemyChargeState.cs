using System.Collections.Generic;

namespace Gameplay
{
    public class EnemyChargeState : IState
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

        public EnemyChargeState(List<IAction> actions, float initialTime)
        {
            _actions = actions;
            _initialTime = initialTime;
        }

        public void Update(float deltaTime)
        {
            _timer -= deltaTime;

            if (_timer <= 0f && !_isChargeCompleted)
            {
                ExecuteActions(a => a.ExecuteActions());
                _isChargeCompleted = true;
            }
        }

        public void Enter()
        {
            ExecuteActions(a => a.EnterActions());
            _timer = _initialTime;
        }

        public void Exit()
        {
            ExecuteActions(a => a.ExitActions());
            _timer = _initialTime;
            _isChargeCompleted = false;
        }

        private void ExecuteActions(System.Action<IAction> action)
        {
            foreach (IAction a in _actions)
                action(a);
        }
    }
}