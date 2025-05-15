using System;
using Zenject;

namespace Gameplay
{
    public class WeaponFireController
    {
        private readonly ICharacterProvider _playerCharacter;
        private readonly WeaponShootComponent _weaponShootComponent;

        public WeaponFireController(ICharacterProvider playerCharacter, WeaponShootComponent weaponShootComponent)
        {
            _playerCharacter = playerCharacter;
            _weaponShootComponent = weaponShootComponent;
        }

        public void TurnOff()
        {
            _playerCharacter.Character.Get<ICharacter>().OnShoot -= _weaponShootComponent.Shoot;
        }

        public void TurnOn()
        {
            _playerCharacter.Character.Get<ICharacter>().OnShoot += _weaponShootComponent.Shoot;
        }
    }
}