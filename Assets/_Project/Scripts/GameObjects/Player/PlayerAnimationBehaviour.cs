using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerAnimationBehaviour : ITickable
    {
        private readonly Animator _animator;

        private readonly int IsRunning = Animator.StringToHash("IsRunning");
        private readonly int IsIdling = Animator.StringToHash("IsIdling");

        public PlayerAnimationBehaviour(Animator animator)
        {
            _animator = animator;
        }

        public void Tick()
        {
            _animator.SetBool(IsRunning, true);
            _animator.SetBool(IsIdling, false);

            _animator.SetBool(IsIdling, true);
            _animator.SetBool(IsRunning, false);
        }
    }
}