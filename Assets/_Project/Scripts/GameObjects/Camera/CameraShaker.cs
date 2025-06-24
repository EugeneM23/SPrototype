using System;
using UnityEngine;

namespace Gameplay
{
    public class CameraShaker
    {
        public event Action OnShoot;
        public event Action Onexplosion;
        public event Action OnSmallShake;

        public void ShootShake(string eventName)
        {
            if (eventName == "Shoot")
                OnShoot?.Invoke();
        }

        public void Explosion(string eventName)
        {
            if (eventName == "Explosion")
            {
                Debug.Log(eventName);
                Onexplosion?.Invoke();
            }
        }

        public void SmallShake(string eventName)
        {
            if (eventName == "SmallShake")
            {
                Debug.Log(eventName);
                OnSmallShake?.Invoke();
            }
        }
    }
}