using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerMoveComponent
    {
        private readonly CharacterController _characterController;

        [Inject(Id = CharacterParameterID.RunSpeed)]
        private float _speed;

        public PlayerMoveComponent(
            CharacterController characterController
        )
        {
            _characterController = characterController;
        }

        public void Move(Vector3 direction)
        {
            direction += Physics.gravity;
            _characterController.Move(direction * _speed * Time.deltaTime);
        }

        public void AddSpeed(float speedPerStack)
        {
            if (_speed + speedPerStack < 0)
            {
                _speed = 0;
                return;
            }
            
            _speed += speedPerStack;
        }
    }
}