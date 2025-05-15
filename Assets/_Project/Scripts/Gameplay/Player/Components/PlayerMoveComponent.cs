using UnityEngine;

namespace Gameplay
{
    public class PlayerMoveComponent
    {
        private readonly CharacterController _characterController;
        private readonly float _speed;

        public PlayerMoveComponent(float speed, CharacterController characterController)
        {
            _speed = speed;
            _characterController = characterController;
        }

        public void Move(Vector3 direction)
        {
            direction += Physics.gravity;
            _characterController.Move(direction * _speed * Time.deltaTime);
        }
    }
}