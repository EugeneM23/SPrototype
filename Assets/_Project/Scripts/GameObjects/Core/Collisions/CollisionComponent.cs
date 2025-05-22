using System;
using UnityEngine;

namespace Gameplay
{
    public class CollisionComponent : MonoBehaviour
    {
        public event Action<Collision> OnHit;

        private void OnCollisionEnter(Collision other)
        {
            OnHit?.Invoke(other);
        }
    }
}