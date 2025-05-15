using Modules;
using Zenject;

namespace Gameplay
{
    public class PlayerRotationController : ITickable
    {
        private readonly PlayerInput _playerInput;
        private readonly RotationComponent _rotationComponent;

        public PlayerRotationController(PlayerInput playerInput, RotationComponent rotationComponent)
        {
            _playerInput = playerInput;
            _rotationComponent = rotationComponent;
        }

        public void Tick()
        {
            _rotationComponent.Ratation(_playerInput.Axis.normalized);
        }
    }
}