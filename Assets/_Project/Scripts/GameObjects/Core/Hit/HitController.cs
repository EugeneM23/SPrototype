using Zenject;

namespace Gameplay
{
    public class HitController : IInitializable
    {
        private readonly HealthComponent _healthComponent;
        private readonly HitComponent _hitComponent;

        public HitController(HealthComponent healthComponent, HitComponent hitComponent)
        {
            _healthComponent = healthComponent;
            _hitComponent = hitComponent;
        }

        public void Initialize()
        {
            _healthComponent.OnTakeDamaged += _hitComponent.Hit;
        }
    }
}