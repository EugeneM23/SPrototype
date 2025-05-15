using UnityEngine;

namespace Gameplay
{
    public class EnviromentHitEffectComponent
    {
        private ParticleSystem _impactParticles;

        public EnviromentHitEffectComponent(ParticleSystem impactParticles)
        {
            _impactParticles = impactParticles;
        }

        public void SpawnImpactEffect(Collision collision)
        {
            ContactPoint contact = collision.GetContact(0);

            Quaternion rotation = Quaternion.LookRotation(contact.normal);
            Object.Instantiate(_impactParticles, contact.point, rotation);
        }
    }
}