using System;
using UnityEngine;

namespace Gameplay
{
    public class CollisionComponent : MonoBehaviour
    {
        public event Action<Collision> OnCollision;

        private void OnCollisionEnter(Collision collision)
        {
            OnCollision?.Invoke(collision);
        }
    }
}