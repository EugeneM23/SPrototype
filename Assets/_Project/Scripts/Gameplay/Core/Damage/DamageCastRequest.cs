using UnityEngine;

namespace Gameplay
{
    public class DamageCastRequest
    {
        public int Damage;
        public float Radius;
        public LayerMask LayerMask;
        public Transform Source;
        public float Time;
    }
}