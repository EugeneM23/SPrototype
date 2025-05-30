using Zenject;

namespace Gameplay
{
    public class EnemyTargetManager : IInitializable
    {
        private readonly PlayerCharacterProvider _playerCharacterProvider;
        private readonly TargetComponent _targetComponent;

        public EnemyTargetManager(PlayerCharacterProvider playerCharacterProvider, TargetComponent targetComponent)
        {
            _playerCharacterProvider = playerCharacterProvider;
            _targetComponent = targetComponent;
        }

        public void Initialize()
        {
            if (_playerCharacterProvider.Character == null) return;

            _targetComponent.Target = _playerCharacterProvider.Character.transform;
        }
    }
}