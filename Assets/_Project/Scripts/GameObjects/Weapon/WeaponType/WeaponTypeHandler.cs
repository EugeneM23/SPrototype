namespace Gameplay
{
    public class WeaponTypeHandler
    {
        public WeaponType WeaponType { get; private set; }

        public WeaponTypeHandler(WeaponType weaponType) => WeaponType = weaponType;
    }
}