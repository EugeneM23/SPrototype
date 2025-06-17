using System;
using UnityEngine;
using Zenject;

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