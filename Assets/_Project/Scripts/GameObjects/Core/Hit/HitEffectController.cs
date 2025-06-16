using Zenject;

namespace Gameplay
{
    public class HitEffectController : IInitializable
    {
        private readonly HealthComponent _health;
        private readonly HitEffectComponent _hitEffectComponent;

        public HitEffectController(HealthComponent health, HitEffectComponent hitEffectComponent)
        {
            _health = health;
            _hitEffectComponent = hitEffectComponent;
        }

        public void Initialize()
        {
            _health.OnTakeDamaged += _hitEffectComponent.CreateHitEffect;
        }
    }

    public class DeathEffectController : IInitializable
    {
        private readonly HealthComponent _health;
        private readonly DeathEffectComponent _deathEffectComponent;

        public DeathEffectController(HealthComponent health, DeathEffectComponent deathEffectComponent)
        {
            _health = health;
            _deathEffectComponent = deathEffectComponent;
        }

        public void Initialize()
        {
            _health.OnDead += _deathEffectComponent.CreateDeathEffect;
        }
    }
}