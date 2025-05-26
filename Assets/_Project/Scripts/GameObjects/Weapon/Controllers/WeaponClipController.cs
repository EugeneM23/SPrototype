using Zenject;

namespace Gameplay
{
    public class WeaponClipController : WeaponReloadComponent.IAction
    {
        private readonly Inventory _inventory;
        private readonly WeaponClipComponent _clip;

        public WeaponClipController(Inventory inventory, WeaponClipComponent clip)
        {
            _inventory = inventory;
            _clip = clip;
        }

        public void StartRealod()
        {
        }

        public void FinishReload()
        {
            if (_clip.MaxCapacity <= _inventory.BulletCount)
            {
                _clip.CurrentCapacity = _clip.MaxCapacity;
                _inventory.BulletCount -= _clip.MaxCapacity;
            }
            else
            {
                _clip.CurrentCapacity = _inventory.BulletCount;
                _inventory.BulletCount = 0;
            }
        }
    }
}