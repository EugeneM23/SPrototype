using Zenject;

namespace Gameplay
{
    public class EnemyCharacterProvider : ICharacterProvider
    {
        private readonly Entity _character;

        public Entity Character => _character;

        public EnemyCharacterProvider(Entity entity)
        {
            _character = entity;
        }
    }
}