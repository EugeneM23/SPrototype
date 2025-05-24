using System;

namespace Gameplay
{
    public class Enemy : IShootable
    {
        public event Action OnShoot;

        public void Shoot()
        {
            OnShoot?.Invoke();
        }
    }
}