using UnityEngine;

namespace Gameplay
{
    public class HitComponent
    {
        private readonly Entity _hitEffect;
        private readonly GameFactory _factory;
        private readonly Transform _hitPoint;

        public HitComponent(Entity hitEffect, GameFactory factory, Transform hitPoint)
        {
            _hitEffect = hitEffect;
            _factory = factory;
            _hitPoint = hitPoint;
        }

        public void Hit(int i)
        {
            var go = _factory.Create(_hitEffect);
            go.transform.position = _hitPoint.position;
        }
    }
}