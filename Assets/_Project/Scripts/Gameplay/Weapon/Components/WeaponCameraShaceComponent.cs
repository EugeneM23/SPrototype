using DPrototype.Game;

namespace Gameplay
{
    public class WeaponCameraShaceComponent : WeaponShootComponent.IAction
    {
        private readonly CameraShakeComponent _cameraShakeComponent;
        private readonly WeaponSetings _setings;

        public WeaponCameraShaceComponent(CameraShakeComponent cameraShakeComponent,
            WeaponSetings setings)
        {
            _cameraShakeComponent = cameraShakeComponent;
            _setings = setings;
        }

        public void Invoke()
        {
            _cameraShakeComponent.CameraShake(_setings.CameraShakeMagnitude, _setings.CameraShakeDuration);
        }
    }
}