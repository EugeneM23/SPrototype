using Zenject;

namespace Gameplay
{
    public class TakeDamageEffectSpawnController : IInitializable
    {
        private readonly CollisionComponent _playerHealth;
        private PlayEffectComponent _playEffectComponentSpawner;

        public TakeDamageEffectSpawnController(PlayEffectComponent playEffectComponentSpawner, CollisionComponent playerHealth)
        {
            _playEffectComponentSpawner = playEffectComponentSpawner;
            _playerHealth = playerHealth;
        }

        public void Initialize()
        {
            _playerHealth.OnHit += _playEffectComponentSpawner.Play;
        }
    }
}