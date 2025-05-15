using Zenject;

namespace Gameplay
{
    public class EnemyTakeDamageController : IInitializable
    {
        private readonly HealthComponentBase _healthComponent;
        private readonly DamageNumberSpawner _damageNumber;

        public EnemyTakeDamageController(HealthComponentBase healthComponent, DamageNumberSpawner damageNumber)
        {
            _healthComponent = healthComponent;
            _damageNumber = damageNumber;
        }

        public void Initialize()
        {
            _healthComponent.OnTakeDamaged += _damageNumber.SpawnPopup;
        }
    }
}