using System;

namespace Gameplay
{
    public sealed class BaseState : IState
    {
        private readonly System.Action _onEnter;
        private readonly System.Action _onExit;
        private readonly Action<float> _onUpdate;

        public BaseState(System.Action onEnter = null, System.Action onExit = null, Action<float> onUpdate = null)
        {
            _onEnter = onEnter;
            _onExit = onExit;
            _onUpdate = onUpdate;
        }

        public void Enter()
        {
            _onEnter?.Invoke();
        }

        public void Exit()
        {
            _onExit?.Invoke();
        }

        public void Update(float deltaTime)
        {
            _onUpdate?.Invoke(deltaTime);
        }
    }
}
