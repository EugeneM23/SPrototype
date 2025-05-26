using Zenject;

namespace Gameplay
{
    public class WeaponClipController : IInitializable
    {
        private readonly Inventory _inventory;
        private readonly WeaponClipComponent _clip;

        public WeaponClipController(Inventory inventory, WeaponClipComponent clip)
        {
            _inventory = inventory;
            _clip = clip;
        }

        public void Initialize()
        {
            /*_inventory.OnBulletCountChanget += SetBulletCount;
            SetBulletCount(_inventory.BulletCount);*/
        }

        
    }
}