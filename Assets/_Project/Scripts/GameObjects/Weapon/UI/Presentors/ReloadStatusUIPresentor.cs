using Zenject;

namespace Gameplay
{
    public class ReloadStatusUIPresentor : IInitializable, WeaponReloadComponent.IAction
    {
        private readonly ReloadStatusUI _reloadStatusUI;
        private readonly Entity _weaponEntity;
        private readonly PlayerCharacterProvider _player;

        public ReloadStatusUIPresentor(ReloadStatusUI reloadStatusUI, Entity weaponEntity,
            PlayerCharacterProvider player)
        {
            _reloadStatusUI = reloadStatusUI;
            _weaponEntity = weaponEntity;
            _player = player;
        }

        public void Initialize()
        {
            _weaponEntity.OnEntityDisable += () => _reloadStatusUI.gameObject.SetActive(false);
            _weaponEntity.OnEntityStart += () => _reloadStatusUI.transform.SetParent(_player.Character.transform);
        }

        public void StartReload() => _reloadStatusUI.gameObject.SetActive(true);

        public void FinishReload() => _reloadStatusUI.gameObject.SetActive(false);
    }
}