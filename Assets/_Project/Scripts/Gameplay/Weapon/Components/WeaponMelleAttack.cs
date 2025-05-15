using UnityEngine;

namespace Gameplay
{
    public class WeaponMelleAttack : WeaponShootComponent.IAction, WeaponShootComponent.ICondition
    {
        private readonly WeaponSetings _setings;
        private readonly ICharacterProvider _character;
        private readonly Animator _animator;

        public WeaponMelleAttack(WeaponSetings setings, ICharacterProvider character, Animator animator)
        {
            _setings = setings;
            _character = character;
            _animator = animator;
        }

        public void Attack()
        {
            _animator.Play("PlayerMelle");
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            Attack();
        }

        bool WeaponShootComponent.ICondition.Invoke()
        {
            var distance = Vector3.Distance(_character.Character.transform.position,
                _character.Character.Get<ICharacter>().Target.position);

            return distance <= _setings.FireRange;
        }
    }
}