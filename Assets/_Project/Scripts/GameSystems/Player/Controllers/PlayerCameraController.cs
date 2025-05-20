using Modules;

namespace Gameplay
{
    public class PlayerCameraController
    {
        private readonly FollowComponent _cameraController;
        private readonly Entity _playerTransform;

        public PlayerCameraController(FollowComponent cameraController, Entity playerTransform)
        {
            _cameraController = cameraController;
            _playerTransform = playerTransform;

            _cameraController.SetTarget(_playerTransform.transform);
        }
    }
}