using UnityEngine;

namespace Gameplay
{
    public class ChargeAnimationHandler : EnemyChargeState.IAction
    {
        private readonly Animator _animator;

        public ChargeAnimationHandler(Animator animator)
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

        public void ExecuteActions()
        {
            _animator.Play("Roll");
        }
    }
}