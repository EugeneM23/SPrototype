using Zenject;

namespace Gameplay
{
    public class TakeDamageEffectSpawnController : IInitializable
    {
        private readonly HealthComponentBase _playerHealth;
        private PlayEffectComponent _playEffectComponentSpawner;

        public TakeDamageEffectSpawnController(PlayEffectComponent playEffectComponentSpawner, HealthComponentBase playerHealth)
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