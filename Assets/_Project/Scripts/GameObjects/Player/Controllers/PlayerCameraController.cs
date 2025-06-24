using Modules;
using Zenject;

namespace Gameplay
{
    public class PlayerCameraController
    {
        private readonly FollowComponent _cameraFolow;
        private readonly Entity _playerTransform;

        public PlayerCameraController(
            FollowComponent cameraFolow,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity playerTransform
        )
        {
            _cameraFolow = cameraFolow;
            _playerTransform = playerTransform;

            _cameraFolow.SetTarget(_playerTransform.transform);
        }
    }
}