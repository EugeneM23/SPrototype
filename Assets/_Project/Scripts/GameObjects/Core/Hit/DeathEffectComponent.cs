using UnityEngine;

namespace Gameplay
{
    public class DeathEffectComponent
    {
        private readonly Entity _deathEffect;
        private readonly GameFactory _factory;
        private readonly Transform _hitPoint;

        public DeathEffectComponent(Entity deathEffect, GameFactory factory, Transform hitPoint)
        {
            _deathEffect = deathEffect;
            _factory = factory;
            _hitPoint = hitPoint;
        }

        public void CreateDeathEffect(Entity obj)
        {
            Entity hitEffect = _factory.Create(_deathEffect);
            hitEffect.transform.position = _hitPoint.position;
        }
    }
}