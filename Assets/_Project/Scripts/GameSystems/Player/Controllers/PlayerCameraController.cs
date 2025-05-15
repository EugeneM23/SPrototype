using Modules;

namespace Gameplay
{
    public class PlayerCameraController
    {
        private readonly ObjectFollowComponent _cameraController;
        private readonly Entity _playerTransform;

        public PlayerCameraController(ObjectFollowComponent cameraController, Entity playerTransform)
        {
            _cameraController = cameraController;
            _playerTransform = playerTransform;

            _cameraController.SetTarget(_playerTransform.transform);
        }
    }
}