using UnityEngine;

namespace Gameplay
{
    public class WeaponMelleAttackAction : WeaponShootComponent.IAction
    {
        private readonly Animator _animator;
        private readonly WeaponSetings _setings;

        public WeaponMelleAttackAction(Animator animator, WeaponSetings setings)
        {
            _animator = animator;
            _setings = setings;
        }

        public void Attack()
        {
            _animator.Play("MelleAttack");
            _animator.SetFloat("AttackSpeed", _setings.FireRate);
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            Attack();
        }
    }
}