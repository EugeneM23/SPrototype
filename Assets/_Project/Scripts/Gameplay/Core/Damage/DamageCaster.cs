using UnityEngine;

namespace Gameplay
{
    public class DamageCaster : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private GameObject _characterSkeleton;

        private int _damage;
        private bool _shouldCast;
        private Transform sourceObject;

        private void OnEnable() => _shouldCast = false;

        void Update()
        {
            if (_shouldCast && sourceObject != null)
                if (DoSingleSphereHit(sourceObject.position))
                    _shouldCast = false;
        }

        bool DoSingleSphereHit(Vector3 origin)
        {
            if (Physics.CheckSphere(origin, radius, layerMask))
            {
                var hitCollider = Physics.OverlapSphere(origin, radius, layerMask);
                if (hitCollider.Length > 0)
                {
                    var damageable = hitCollider[0].GetComponentInParent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.TakeDamage(_damage);
                        return true;
                    }
                }
            }

            return false;
        }

        public void CastOn(Transform root, int damage)
        {
            _damage = damage;
            sourceObject = root;
            _shouldCast = true;
        }

        public void CastOff()
        {
            _shouldCast = false;
        }

        void OnDrawGizmos()
        {
            if (sourceObject == null) return;

            if (_shouldCast)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(sourceObject.position, radius);
            }
        }
    }
}