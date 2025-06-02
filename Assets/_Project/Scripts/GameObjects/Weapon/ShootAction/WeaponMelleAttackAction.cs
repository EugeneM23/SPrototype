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

        private CharacterStats _characterStats;

        public WeaponMelleAttackAction(ICharacterProvider character, CharacterStats characterStats)
        {
            _character = character;
            _characterStats = characterStats;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            float animationSpeed = 1f * (1 + _characterStats.FireRateMultupleyer / 100f);

            Debug.Log(animationSpeed);
            _character.Character.Get<Animator>().Play("MelleAttack");
            _character.Character.Get<Animator>().SetFloat("AttackSpeed", animationSpeed);
        }
    }
}