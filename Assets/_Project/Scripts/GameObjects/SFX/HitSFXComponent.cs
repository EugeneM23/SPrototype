using AudioEngine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
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