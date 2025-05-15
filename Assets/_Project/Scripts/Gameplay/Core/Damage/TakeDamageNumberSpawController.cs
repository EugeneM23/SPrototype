using Zenject;

namespace Gameplay
{
    public class TakeDamageNumberSpawController : IInitializable
    {
        private readonly HealthComponentBase _playerHealth;
        private readonly DamageNumberSpawner _damageNumber;

        public TakeDamageNumberSpawController(HealthComponentBase playerHealth, DamageNumberSpawner damageNumber)
        {
            _playerHealth = playerHealth;
            _damageNumber = damageNumber;
        }

        public void Initialize()
        {
            _playerHealth.OnTakeDamaged += _damageNumber.SpawnPopup;
        }
    }
}