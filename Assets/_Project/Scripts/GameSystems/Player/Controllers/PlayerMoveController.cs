using Modules;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Gameplay
{
    public class PlayerMoveController : ITickable
    {
        private readonly GameInput _gameInput;
        private readonly PlayerMoveComponent _moveComponent;

        public PlayerMoveController(GameInput gameInput, PlayerMoveComponent moveComponent)
        {
            _gameInput = gameInput;
            _moveComponent = moveComponent;
        }

        public void Tick()
        {
            _moveComponent.Move(_gameInput.Axis.normalized);
        }
    }
}