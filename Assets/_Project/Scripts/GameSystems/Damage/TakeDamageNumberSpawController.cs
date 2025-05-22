using Zenject;

namespace Gameplay
{
    public class TakeDamageNumberSpawController : IInitializable
    {
        private readonly HealthComponent _healthComponent;
        private readonly DamageNumberSpawner _damageNumber;

        public TakeDamageNumberSpawController(HealthComponent healthComponent, DamageNumberSpawner damageNumber)
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