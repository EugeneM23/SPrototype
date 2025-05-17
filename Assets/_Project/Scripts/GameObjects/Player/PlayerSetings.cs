using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class PlayerSetings
    {
        [field: SerializeField] public float RunSpeed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float LookAtSpeed { get; set; }
        [field: SerializeField] public float StrafeSpeed { get; private set; }
        [field: SerializeField] public float StrafePower { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
    }
}