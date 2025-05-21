using Modules;
using Zenject;

namespace Gameplay
{
    public class PlayerRotationController : ITickable
    {
        private readonly GameInput _gameInput;
        private readonly PlayerCharacterProvider _player;

        public PlayerRotationController(GameInput gameInput, PlayerCharacterProvider player)
        {
            _gameInput = gameInput;
            _player = player;
        }

        public void Tick()
        {
            _player.Character.Get<RotationComponent>().Ratation(_gameInput.Axis.normalized);
        }
    }
}