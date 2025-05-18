using UnityEngine;

namespace Gameplay
{
    public class WeaponMelleAttackAction : WeaponShootComponent.IAction
    {
        private readonly Animator _animator;

        public WeaponMelleAttackAction(Animator animator)
        {
            _animator = animator;
        }

        public void Attack()
        {
            _animator.Play("MelleAttack");
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            Attack();
        }
    }
}