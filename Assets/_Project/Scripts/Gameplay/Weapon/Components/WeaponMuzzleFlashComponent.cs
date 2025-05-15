using UnityEngine;

namespace Gameplay
{
    public class WeaponMuzzleFlashComponent : WeaponShootComponent.IAction
    {
        private readonly ParticleSystem _particle;

        public WeaponMuzzleFlashComponent(ParticleSystem particle)
        {
            _particle = particle;
        }

        public void Invoke()
        {
            _particle.Play(true);
        }
    }
}