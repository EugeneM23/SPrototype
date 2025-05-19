using DPrototype.Game;
using Zenject;

namespace Gameplay
{
    public class WeaponCameraShakeAction : WeaponShootComponent.IAction
    {
        [Inject(Id = WeaponParameterID.ShakeMagnitude)]
        private float _cameraShakeMagnitude;

        [Inject(Id = WeaponParameterID.ShakeDuration)]
        private float _cameraShakeDuration;

        private readonly CameraShakeComponent _cameraShakeComponent;

        public WeaponCameraShakeAction(CameraShakeComponent cameraShakeComponent)

        {
            _cameraShakeComponent = cameraShakeComponent;
        }

        public void Invoke()
        {
            _cameraShakeComponent.CameraShake(_cameraShakeMagnitude, _cameraShakeDuration);
        }
    }
}