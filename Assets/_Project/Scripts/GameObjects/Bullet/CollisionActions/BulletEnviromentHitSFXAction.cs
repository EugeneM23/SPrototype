using AudioEngine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletEnviromentHitSFXAction : IInitializable, BulletHitComponent.IEnviromentCollisionAction
    {
        private readonly AudioEventKey _hitSfx;

        private AudioSystem _audioSystem;

        public BulletEnviromentHitSFXAction(AudioEventKey hitSfx)
        {
            _hitSfx = hitSfx;
        }

        public void Initialize() => _audioSystem = AudioSystem.Instance;

        public void Invoke(RaycastHit hit)
        {
            _audioSystem.PlayEvent(_hitSfx, hit.point);
        }
    }
}