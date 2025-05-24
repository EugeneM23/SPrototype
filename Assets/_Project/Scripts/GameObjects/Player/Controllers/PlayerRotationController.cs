using Modules;
using Zenject;

namespace Gameplay
{
    public class PlayerRotationController : ITickable
    {
        private readonly GameInput _gameInput;

        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _player;

        public PlayerRotationController(GameInput gameInput)
        {
            _gameInput = gameInput;
        }

        public void Tick()
        {
            _player.Get<RotationComponent>().Ratation(_gameInput.Axis.normalized);
        }
    }
}