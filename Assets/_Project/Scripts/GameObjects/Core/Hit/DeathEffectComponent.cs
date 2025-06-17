using UnityEngine;

namespace Gameplay
{
    public class DeathEffectComponent
    {
        private readonly Entity[] _deathEffect;
        private readonly GameFactory _factory;
        private readonly Transform _hitPoint;

        public DeathEffectComponent(Entity[] deathEffect, GameFactory factory, Transform hitPoint)
        {
            _deathEffect = deathEffect;
            _factory = factory;
            _hitPoint = hitPoint;
        }

        public void CreateDeathEffect(Entity obj)
        {
            foreach (var deathEffect in _deathEffect)
            {
                var effect = _factory.Create(deathEffect);
                float randomRotation = Random.Range(-180f, 180f);
                effect.transform.rotation = Quaternion.Euler(0f, randomRotation, 0f);
                effect.transform.position = _hitPoint.position;
            }
        }
    }
}