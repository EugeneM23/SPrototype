using Zenject;

namespace Gameplay
{
    public class HitController : IInitializable
    {
        private readonly HealthComponent _health;
        private readonly HitComponent _hitComponent;

        public HitController(HealthComponent health, HitComponent hitComponent)
        {
            _health = health;
            _hitComponent = hitComponent;
        }

        public void Initialize()
        {
            _health.OnTakeDamaged += _hitComponent.CreateHitEffect;
        }
    }
}