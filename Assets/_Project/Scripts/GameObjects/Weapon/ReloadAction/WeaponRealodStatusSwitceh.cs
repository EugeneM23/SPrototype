namespace Gameplay
{
    public class WeaponRealodStatusSwitceh : WeaponReloadComponent.IAction
    {
        private readonly ICharacterProvider _characterProvider;

        public WeaponRealodStatusSwitceh(ICharacterProvider characterProvider)
        {
            _characterProvider = characterProvider;
        }

        public void StartReload()
        {
            _characterProvider.Character.Get<CharacterConditions>().IsReloaded = true;
        }

        public void FinishReload()
        {
            _characterProvider.Character.Get<CharacterConditions>().IsReloaded = false;
        }
    }
}