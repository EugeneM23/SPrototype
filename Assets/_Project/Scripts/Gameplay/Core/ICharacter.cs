using System;
using UnityEngine;

namespace Gameplay
{
    public interface ICharacter
    {
        public event Action OnShoot;

        public Transform Target { get; set; }
    }
}