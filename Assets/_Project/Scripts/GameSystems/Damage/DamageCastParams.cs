using UnityEngine;

namespace Gameplay
{
    public class DamageCastParams
    {
        public int Damage;
        public float Radius;
        public float Time;
        public LayerMask LayerMask;
        public Transform Source;

        public DamageCastParams(int damage, float radius, float time, LayerMask damagelayer,
            Transform source)
        {
            Damage = damage;
            Radius = radius;
            Time = time;
            LayerMask = damagelayer;
            Source = source;
        }
    }
}