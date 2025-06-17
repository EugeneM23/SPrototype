using System;
using UnityEngine;

namespace Gameplay
{
    public class CollisionComponent : MonoBehaviour
    {
        private bool _isCollided;
        public event Action<Collision> OnHit;

        private void OnEnable()
        {
            _isCollided = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_isCollided)
            {
                Debug.Log("Collision");
                _isCollided = true;
                OnHit?.Invoke(other);
            }
        }
    }
}