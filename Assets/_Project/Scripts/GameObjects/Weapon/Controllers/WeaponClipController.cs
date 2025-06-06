using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponClipController : WeaponReloadComponent.IAction
    {
        private readonly IInventory _inventory;
        private readonly WeaponClipComponent clip;

        public WeaponClipController(IInventory inventory, WeaponClipComponent clip)
        {
            this._inventory = inventory;
            this.clip = clip;
        }

        public void StartRealod()
        {
        }

        public void FinishReload()
        {
            var bulletsToReload = Mathf.Min(clip.MaxCapacity, _inventory.BulletCount);
            clip.CurrentCapacity = bulletsToReload;
            _inventory.BulletCount -= bulletsToReload;
        }
    }
}