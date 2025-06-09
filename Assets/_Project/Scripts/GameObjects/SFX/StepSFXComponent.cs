using AudioEngine;
using Zenject;

namespace Gameplay
{
    public class StepSFXComponent : IInitializable
    {
        private readonly Entity _character;
        private readonly AudioEventKey _stepSound;
        private AudioSystem _audioSystem;

        public StepSFXComponent(AudioEventKey stepSound, Entity character)
        {
            _stepSound = stepSound;
            _character = character;
        }

        public void Initialize()
        {
            _audioSystem = AudioSystem.Instance;
        }

        public void FootStep(string eventName)
        {
            if (eventName == "Step")
                _audioSystem.PlayEvent(_stepSound, _character.transform.position);
        }
    }
}