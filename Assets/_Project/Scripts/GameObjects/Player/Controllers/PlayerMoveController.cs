using Zenject;

namespace Gameplay
{
    public class PlayerMoveController : ITickable
    {
        private readonly GameInput _gameInput;
        private readonly PlayerCharacterProvider _player;

        public PlayerMoveController(GameInput gameInput, PlayerCharacterProvider player)
        {
            _gameInput = gameInput;
            _player = player;
        }

        public void Tick()
        {
            _player.Character.Get<PlayerMoveComponent>().Move(_gameInput.Axis.normalized);
        }
    }
}