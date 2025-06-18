using AudioEngine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletEnviromentHitAction : BulletHitComponent.IEnviromentCollisionAction
    {
        private readonly Entity _effect;
        private readonly GameFactory _factory;

        public BulletEnviromentHitAction(Entity effect, GameFactory factory)
        {
            _effect = effect;
            _factory = factory;
        }

        public void Invoke(RaycastHit hit)
        {
            if (_effect == null) return;

            Quaternion rotation = Quaternion.LookRotation(hit.normal);
            Entity effect = _factory.Create(_effect);

            effect.transform.SetPositionAndRotation(hit.point, rotation);
        }
    }

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