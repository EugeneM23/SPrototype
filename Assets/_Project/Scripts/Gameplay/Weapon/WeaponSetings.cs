using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class WeaponSetings
    {
        [field: SerializeField] public float FireRate { get; private set; }
        [field: SerializeField] public float Scatter { get; private set; }
        [field: SerializeField] public float FireRange { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float BulletSpeed { get; private set; }
        [field: SerializeField] public float CameraShakeDuration { get; private set; }
        [field: SerializeField] public float CameraShakeMagnitude { get; private set; }
        [field: SerializeField] public float ShellImpulse { get; private set; }
        [field: SerializeField] public float RacoilPower { get; private set; }
        [field: SerializeField] public int ProjectileCount { get; private set; }
        [field: SerializeField] public int MaxRicochetCount { get; private set; }
    }
}