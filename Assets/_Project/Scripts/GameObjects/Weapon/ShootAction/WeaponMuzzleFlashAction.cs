using UnityEngine;

namespace Gameplay
{
    public class WeaponMuzzleFlashAction : WeaponShootComponent.IAction
    {
        private readonly Entity _particle;
        private readonly GameFactory _factory;
        private readonly Transform _firePoint;

        public WeaponMuzzleFlashAction(Entity particle, GameFactory factory, Transform firePoint)
        {
            _particle = particle;
            _factory = factory;
            _firePoint = firePoint;
        }

        public void Invoke()
        {
            if (_particle == null) return;

            var effect = _factory.Create(_particle);
            effect.gameObject.SetActive(false);
            effect.transform.position = _firePoint.position;
            effect.transform.rotation = _firePoint.rotation;
            effect.gameObject.SetActive(true);
        }
    }
}