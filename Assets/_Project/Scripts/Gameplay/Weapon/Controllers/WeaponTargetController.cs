using UnityEngine;

namespace Gameplay
{
    public class WeaponTargetController : WeaponShootComponent.IAction
    {
        private readonly ICharacterProvider _character;
        private readonly WeaponTargetComponent _targetComponent;

        public WeaponTargetController(ICharacterProvider character,
            WeaponTargetComponent targetComponent)
        {
            _character = character;
            _targetComponent = targetComponent;
        }

        public void Invoke()
        {
            _targetComponent.Target = _character.Character.Get<ICharacter>().Target;
        }
    }
}