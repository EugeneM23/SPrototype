using Zenject;

namespace Gameplay
{
    public class TakeDamageNumberSpawController : IInitializable
    {
        private readonly TakeDamageComponent _healthComponent;
        private readonly DamageNumberSpawner _damageNumber;

        public TakeDamageNumberSpawController(TakeDamageComponent healthComponent, DamageNumberSpawner damageNumber)
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