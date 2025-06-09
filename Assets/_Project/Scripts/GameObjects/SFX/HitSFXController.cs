using Zenject;

namespace Gameplay
{
    public class HitSFXController : IInitializable
    {
        private readonly HealthComponent _health;
        private readonly HitSFXComponent _hitSfxComponent;

        public HitSFXController(HealthComponent health, HitSFXComponent hitSfxComponent)
        {
            _health = health;
            _hitSfxComponent = hitSfxComponent;
        }

        public void Initialize()
        {
            _health.OnTakeDamaged += _hitSfxComponent.PlayHitSFX;
        }
    }
}