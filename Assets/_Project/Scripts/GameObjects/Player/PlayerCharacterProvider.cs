using Zenject;

namespace Gameplay
{
    public class PlayerCharacterProvider : ICharacterProvider
    {
        private readonly Entity _character;

        public Entity Character => _character;

        public PlayerCharacterProvider([Inject(Id = CharacterParameterID.CharacterEntity)] Entity entity)
        {
            _character = entity;
        }
    }

    public interface ICharacterProvider
    {
        public Entity Character { get; }
    }
}