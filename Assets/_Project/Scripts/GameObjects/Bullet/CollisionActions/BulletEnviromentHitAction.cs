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

        public void Invoke(Collision collision)
        {
            if (_effect == null) return;

            ContactPoint point = collision.contacts[0];
            Quaternion rotation = Quaternion.LookRotation(point.normal);
            var effect = _factory.Create(_effect);
            effect.transform.position = point.point;
            effect.transform.rotation = rotation;
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

        public void Invoke(Collision collision)
        {
            ContactPoint point = collision.contacts[0];
            _audioSystem.PlayEvent(_hitSfx, point.point);
        }
    }
}