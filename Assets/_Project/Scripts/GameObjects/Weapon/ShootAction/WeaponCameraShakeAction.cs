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

        private readonly CameraShaker _cameraShaker;

        public WeaponCameraShakeAction(CameraShaker cameraShaker)

        {
            _cameraShaker = cameraShaker;
        }

        public void Invoke()
        {
            _cameraShaker.CameraShake(_cameraShakeMagnitude, _cameraShakeDuration);
        }
    }
}