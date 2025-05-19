using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponShootAnimationAction : WeaponShootComponent.IAction
    {
        private readonly ICharacterProvider _character;

        [Inject(Id = WeaponParameterID.FireRate)]
        private float _fireRate;

        public WeaponShootAnimationAction(ICharacterProvider character)
        {
            _character = character;
        }

        public void Invoke()
        {
            float animationSpeed = 1f / _fireRate;

            _character.Character.Get<Animator>().Play("RangeAttack");
            _character.Character.Get<Animator>().SetFloat("AttackSpeed", animationSpeed);
        }
    }
}