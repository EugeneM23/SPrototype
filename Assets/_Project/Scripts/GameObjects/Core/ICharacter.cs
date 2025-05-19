using System;
using UnityEngine;

namespace Gameplay
{
    public interface ICharacter
    {
        public event System.Action OnShoot;

        public Transform Target { get; set; }

        public void Shoot();
    }
}