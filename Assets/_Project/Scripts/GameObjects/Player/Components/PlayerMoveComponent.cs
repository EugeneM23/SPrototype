using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerMoveComponent : IInitializable, IMove
    {
        private readonly CharacterController _characterController;
        private readonly CharacterStats _stats;

        private float _speed;

        public PlayerMoveComponent(CharacterController characterController, CharacterStats stats)
        {
            _characterController = characterController;
            _stats = stats;
        }

        public void Initialize() => _speed = _stats.RunSpeed;

        public void Move(Vector3 direction)
        {
            direction += Physics.gravity;
            _characterController.Move(direction * GetSpeed() * Time.deltaTime);
        }

        private float GetSpeed() => _stats.RunSpeed * (1 + _stats.RunSpeedMultiplier / 100f);
    }
}