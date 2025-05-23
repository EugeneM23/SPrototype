namespace Gameplay
{
    public class WeaponSootCounAction : WeaponShootComponent.IAction, WeaponShootComponent.ICondition
    {
        private readonly WeaponClipComponent _clip;

        public WeaponSootCounAction(WeaponClipComponent clip)
        {
            _clip = clip;
        }

        public void Invoke()
        {
            _clip.Count();
        }

        bool WeaponShootComponent.ICondition.Invoke()
        {
            return _clip.CurrentCapacity > 0;
        }
    }
}