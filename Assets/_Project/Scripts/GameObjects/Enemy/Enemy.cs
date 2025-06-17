using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Enemy : IShootable
    {
        private readonly CharacterConditions _characterConditions;

        public Enemy(CharacterConditions characterConditions)
        {
            _characterConditions = characterConditions;
        }

        public event Action OnShoot;

        public void Shoot()
        {
            if (!_characterConditions.IsAlive) return;

            OnShoot?.Invoke();
        }
    }
}