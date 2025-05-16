using System;
using Zenject;

namespace Gameplay
{
    public class WeaponFireController
    {
        private readonly ICharacterProvider _character;
        private readonly WeaponShootComponent _weaponShootComponent;

        public WeaponFireController(ICharacterProvider character, WeaponShootComponent weaponShootComponent)
        {
            _character = character;
            _weaponShootComponent = weaponShootComponent;
        }

        public void TurnOff()
        {
            _character.Character.Get<ICharacter>().OnShoot -= _weaponShootComponent.Shoot;
        }

        public void TurnOn()
        {
            _character.Character.Get<ICharacter>().OnShoot += _weaponShootComponent.Shoot;
        }
    }
}