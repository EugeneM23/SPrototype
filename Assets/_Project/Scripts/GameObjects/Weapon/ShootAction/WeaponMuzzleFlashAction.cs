using UnityEngine;

namespace Gameplay
{
    public class WeaponMuzzleFlashAction : WeaponShootComponent.IAction
    {
        private readonly ParticleSystem _particle;

        public WeaponMuzzleFlashAction(ParticleSystem particle)
        {
            _particle = particle;
        }

        public void Invoke()
        {
            if (_particle == null) return;
            
            _particle.Play(true);
        }
    }
}