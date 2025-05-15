using Modules;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Gameplay
{
    public class PlayerMoveController : ITickable
    {
        private readonly PlayerInput _playerInput;
        private readonly CharacterMoveComponent _moveComponent;

        public PlayerMoveController(PlayerInput playerInput, CharacterMoveComponent moveComponent)
        {
            _playerInput = playerInput;
            _moveComponent = moveComponent;
        }

        public void Tick()
        {
            _moveComponent.Move(_playerInput.Axis.normalized);
        }
    }
}