using UnityEngine;

namespace Gameplay
{
    public class AnimationChargeComponent : EnemyChargeState.IAction
    {
        private readonly Animator _animator;

        public AnimationChargeComponent(Animator animator)
        {
            _animator = animator;
        }

        public void EnterActions()
        {
            _animator.Play("Charge");
        }

        public void ExitActions()
        {
        }
    }
}