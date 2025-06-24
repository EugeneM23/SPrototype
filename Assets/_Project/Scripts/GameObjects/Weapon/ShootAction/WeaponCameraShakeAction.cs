using DPrototype.Game;

namespace Gameplay
{
    public class WeaponCameraShakeAction : WeaponShootComponent.IAction
    {
        private readonly CameraShaker _cameraShaker;

        public WeaponCameraShakeAction(CameraShaker cameraShaker)

        {
            _cameraShaker = cameraShaker;
        }

        public void Invoke()
        {
            _cameraShaker.ShootShake();
        }
    }
}