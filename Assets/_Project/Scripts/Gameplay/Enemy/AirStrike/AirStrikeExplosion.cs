using UnityEngine;

namespace Gameplay
{
    public class AirStrikeExplosion : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private void OnEnable() => _particleSystem.Stop();

        public void Explode()
        {
            _particleSystem.Play();
        }
    }
}