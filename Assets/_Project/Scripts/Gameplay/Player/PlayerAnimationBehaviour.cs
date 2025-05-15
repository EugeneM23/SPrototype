using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerAnimationBehaviour : ITickable
    {
        private readonly Animator _animator;
        private readonly CharacterController _characterController;

        private static readonly int
            IsRunning = Animator.StringToHash("IsRunning");

        private static readonly int IsIdling = Animator.StringToHash("IsIdling");

        public PlayerAnimationBehaviour(Animator animator, CharacterController characterController)
        {
            _animator = animator;
            _characterController = characterController;
        }

        public void Tick()
        {
            if (_characterController.velocity != Vector3.zero)
            {
                _animator.SetBool(IsRunning, true);
                _animator.SetBool(IsIdling, false);
            }
            else
            {
                _animator.SetBool(IsIdling, true);
                _animator.SetBool(IsRunning, false);
            }
        }
    }
}