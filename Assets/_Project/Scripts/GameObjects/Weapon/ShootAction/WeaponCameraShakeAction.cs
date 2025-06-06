using DPrototype.Game;
using Zenject;

namespace Gameplay
{
    public class WeaponCameraShakeAction : WeaponShootComponent.IAction
    {
        private readonly WeaponConfig _config;
        private readonly CameraShaker _cameraShaker;

        public WeaponCameraShakeAction(CameraShaker cameraShaker, WeaponConfig config)

        {
            _cameraShaker = cameraShaker;
            _config = config;
        }

        public void Invoke()
        {
            _cameraShaker.CameraShake(_config.shakeMagnitude, _config.shakeDuration);
        }
    }
}