using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Enemy : ITickable, ICharacter
    {
        public event Action OnShoot;
        public Transform Target { get; set; }

        private PlayerCharacterProvider _character;

        public Enemy(PlayerCharacterProvider character)
        {
            _character = character;
            Target = _character.Character.transform;
        }

        public void Tick()
        {
        }

        public void Shoot()
        {
            OnShoot?.Invoke();
        }
    }
}