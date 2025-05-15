namespace Gameplay
{
    public class PlayerCharacterProvider : ICharacterProvider
    {
        private readonly Entity _character;

        public Entity Character => _character;

        public PlayerCharacterProvider(Entity entity)
        {
            _character = entity;
        }
    }

    public class EnemyCharacterProvider : ICharacterProvider
    {
        private readonly Entity _character;

        public Entity Character => _character;

        public EnemyCharacterProvider(Entity entity)
        {
            _character = entity;
        }
    }

    public interface ICharacterProvider
    {
        public Entity Character { get; }
    }
}