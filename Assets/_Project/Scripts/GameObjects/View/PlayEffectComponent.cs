using UnityEngine;

namespace Gameplay
{
    public class PlayEffectComponent
    {
        private ParticleSystem _particleSystem;

        public PlayEffectComponent(ParticleSystem particleSystem) => _particleSystem = particleSystem;

        public void Play(Collision collision)
        {
            _particleSystem.gameObject.SetActive(true);
            _particleSystem.Play();
        }

        
    }
}