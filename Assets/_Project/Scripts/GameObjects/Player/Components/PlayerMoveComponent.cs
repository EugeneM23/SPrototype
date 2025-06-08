using System;
using AudioEngine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerMoveComponent : IMove
    {
        private readonly CharacterController _characterController;
        private readonly CharacterStats _stats;

        public PlayerMoveComponent(CharacterController characterController, CharacterStats stats)
        {
            _characterController = characterController;
            _stats = stats;
        }

        public void Move(Vector3 direction)
        {
            direction += Physics.gravity;
            _characterController.Move(direction * GetSpeed() * Time.deltaTime);
        }

        private float GetSpeed() => _stats.RunSpeed * (1 + _stats.RunSpeedMultiplier / 100f);
    }

    public class PlayerFootStepSFX : ITickable, IInitializable
    {
        private readonly AudioEventKey _stepSound;
        private readonly CharacterConditions _character;

        private AudioSystem _audioSystem;
        private float _timer;
        private const float STEP_TIME = 0.3f;

        public PlayerFootStepSFX(AudioEventKey stepSound, CharacterConditions character)
        {
            _stepSound = stepSound;
            _character = character;
        }

        public void Initialize()
        {
            _audioSystem = AudioSystem.Instance;
        }

        public void Tick()
        {
            _timer -= Time.deltaTime;
            if (_timer >= 0 || !_character.IsChasing) return;

            _audioSystem.PlayEvent(_stepSound);
            _timer = STEP_TIME;
        }
    }
}