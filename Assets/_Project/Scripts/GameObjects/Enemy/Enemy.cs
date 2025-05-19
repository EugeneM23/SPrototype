using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Enemy : ICharacter
    {
        public event System.Action OnShoot;
        public Transform Target { get; set; }
        public int Damage { get; }

        private readonly PlayerCharacterProvider _character;

        public Enemy(PlayerCharacterProvider character)
        {
            _character = character;
            Target = _character.Character.transform;
        }

        public void Shoot()
        {
            OnShoot?.Invoke();
        }
    }
}