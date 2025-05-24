using Zenject;

namespace Gameplay
{
    public class PlayerCharacterProvider : ICharacterProvider
    {
        private Entity _character;

        public Entity Character => _character;

        public void SetCharacter(Entity getComponent)
        {
            _character = getComponent;
        }
    }

    public interface ICharacterProvider
    {
        public Entity Character { get; }
    }
}