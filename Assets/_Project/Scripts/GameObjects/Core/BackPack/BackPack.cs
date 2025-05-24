using Zenject;

namespace Gameplay
{
    public class BackPack
    {
        private readonly Entity _firstWeapon;
        private readonly Entity _secondWeapon;

        public BackPack(
            [Inject(Id = WeaponParameterID.FisrstWeapon)]
            Entity firstWeapon,
            [Inject(Id = WeaponParameterID.SecondWeapon)]
            Entity secondWeapon
        )
        {
            _firstWeapon = firstWeapon;
            _secondWeapon = secondWeapon;
        }
    }
}