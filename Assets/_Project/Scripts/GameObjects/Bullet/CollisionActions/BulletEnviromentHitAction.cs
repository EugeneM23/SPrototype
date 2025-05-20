using UnityEngine;

namespace Gameplay
{
    public class BulletEnviromentHitAction : CollisionComponent.IEnviromentCollisionAction
    {
        private readonly ParticleSystem _particleSystem;

        public BulletEnviromentHitAction(ParticleSystem particleSystem)
        {
            _particleSystem = particleSystem;
        }

        public void Invoke(Collision collision)
        {
            ContactPoint point = collision.contacts[0];
            Quaternion rotation = Quaternion.LookRotation(point.normal);
            Object.Instantiate(_particleSystem, collision.contacts[0].point, rotation);
        }
    }
}