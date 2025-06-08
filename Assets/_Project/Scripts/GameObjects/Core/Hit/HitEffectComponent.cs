using UnityEngine;

namespace Gameplay
{
    public class HitEffectComponent
    {
        private readonly Entity _hitEffect;
        private readonly GameFactory _factory;
        private readonly Transform _hitPoint;

        public HitEffectComponent(Entity hitEffect, GameFactory factory, Transform hitPoint)
        {
            _hitEffect = hitEffect;
            _factory = factory;
            _hitPoint = hitPoint;
        }

        public void CreateHitEffect(int damage)
        {
            Entity hitEffect = _factory.Create(_hitEffect);
            hitEffect.transform.position = _hitPoint.position;
        }
    }
}