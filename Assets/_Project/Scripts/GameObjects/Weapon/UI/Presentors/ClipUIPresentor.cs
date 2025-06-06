using Zenject;

namespace Gameplay
{
    public class ClipUIPresentor : IInitializable, WeaponReloadComponent.IAction
    {
        private readonly ClipUI _clipUI;

        private readonly WeaponClipComponent _clip;
        private readonly Entity _weaponEntity;
        private readonly IInventory _inventory;

        public ClipUIPresentor(ClipUI clipUI, WeaponClipComponent clip, Entity weaponEntity, IInventory inventory)
        {
            _clipUI = clipUI;
            _clip = clip;
            _weaponEntity = weaponEntity;
            _inventory = inventory;
        }

        public void Initialize()
        {
            _clip.OnCurrentCapacityChanget += UpdataCurrentCapacity;
            _inventory.OnBulletCountChanget += UpdateBulletCount;

            _weaponEntity.OnEntityDisable += () => _clipUI.Disable();
            _weaponEntity.OnEntityEnable += () => _clipUI.Enable();

            _weaponEntity.OnEntityStart += () => UpdateBulletCount();
            _weaponEntity.OnEntityStart += () => _clipUI.UpdataCurrentCapacity(_clip.CurrentCapacity);
        }

        private void UpdateBulletCount() => _clipUI.UpdateBulletCount(_inventory.BulletCount);

        private void UpdataCurrentCapacity(int value)
        {
            _clipUI.UpdataCurrentCapacity(value);
        }

        public void StartRealod()
        {
        }

        public void FinishReload() => UpdataCurrentCapacity(_clip.CurrentCapacity);
    }
}