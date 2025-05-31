using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponMelleAttackAction : WeaponShootComponent.IAction
    {
        private readonly ICharacterProvider _character;

        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _characterEntity;

        [Inject(Id = WeaponParameterID.AttackRate)]
        private readonly float _attackRate;

        [Inject] private CharacterStats _characterStats;

        public WeaponMelleAttackAction(ICharacterProvider character)
        {
            _character = character;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            float animationSpeed = 1f / _attackRate / (_characterStats.FireRateMultupleyer);

            _character.Character.Get<Animator>().Play("MelleAttack");
            _character.Character.Get<Animator>().SetFloat("AttackSpeed", animationSpeed);
        }
    }
}