using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class AirStrikeExplosion : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private DamageCastLayer _layerMask;
        [Inject] private readonly DamageCasterManager _damageCasterManager;

        private void OnEnable() => _particleSystem.Stop();

        public void Explode()
        {
            DamageCastParams cast = new DamageCastParams(50, 2, 0.5f, _layerMask, gameObject.transform);
            _particleSystem.Play();
            _damageCasterManager.CastDamage(cast);
        }
    }
}