using System;

namespace Gameplay
{
    public class CameraShaker
    {
        public event Action OnShoot;

        public void ShootShake()
        {
            OnShoot?.Invoke();
        }
    }
}