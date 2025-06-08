using AudioEngine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class HitEffectController : IInitializable
    {
        private readonly HealthComponent _health;
        private readonly HitEffectComponent _hitEffectComponent;

        public HitEffectController(HealthComponent health, HitEffectComponent hitEffectComponent)
        {
            _health = health;
            _hitEffectComponent = hitEffectComponent;
        }

        public void Initialize()
        {
            _health.OnTakeDamaged += _hitEffectComponent.CreateHitEffect;
        }
    }

    public class HitSFXController : IInitializable
    {
        private readonly HealthComponent _health;
        private readonly HitSFXComponent _hitSfxComponent;

        public HitSFXController(HealthComponent health, HitSFXComponent hitSfxComponent)
        {
            _health = health;
            _hitSfxComponent = hitSfxComponent;
        }

        public void Initialize()
        {
            _health.OnTakeDamaged += _hitSfxComponent.PlayHitSFX;
        }
    }

    public class HitSFXComponent : IInitializable
    {
        private readonly AudioEventKey _key;
        private readonly Entity _character;

        private AudioSystem _audioSystem;

        public HitSFXComponent([Inject(Id = CharacterParameterID.CharacterEntity)] Entity character, AudioEventKey key)
        {
            _character = character;
            _key = key;
        }

        public void Initialize() => _audioSystem = AudioSystem.Instance;

        public void PlayHitSFX(int obj)
        {
            Debug.Log("sadasd");
            _audioSystem.PlayEvent(_key, _character.transform.position, _character.transform.rotation, 0.05f);
        }
    }
}