using Zenject;

namespace Gameplay
{
    public class PlayerMoveController : ITickable, ILateTickable
    {
        private readonly GameInput _gameInput;

        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _player;

        public PlayerMoveController(GameInput gameInput)
        {
            _gameInput = gameInput;
        }

        public void Tick()
        {
        }

        public void LateTick()
        {
            _player.Get<PlayerMoveComponent>().Move(_gameInput.Axis.normalized);
        }
    }
}