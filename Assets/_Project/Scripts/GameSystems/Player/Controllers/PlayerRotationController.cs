using Modules;
using Zenject;

namespace Gameplay
{
    public class PlayerRotationController : ITickable
    {
        private readonly GameInput _gameInput;
        private readonly RotationComponent _rotationComponent;

        public PlayerRotationController(GameInput gameInput, RotationComponent rotationComponent)
        {
            _gameInput = gameInput;
            _rotationComponent = rotationComponent;
        }

        public void Tick()
        {
            _rotationComponent.Ratation(_gameInput.Axis.normalized);
        }
    }
}