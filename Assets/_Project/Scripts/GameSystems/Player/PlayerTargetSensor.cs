using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerTargetSensor : MonoBehaviour
    {
        public event System.Action OnTargetChanget;

        [SerializeField] private float _refreshRate;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _radius;
        [SerializeField] private bool _shouldCast = true;

        [Inject] private Player _player;

        private Transform _target;
        private float _lastRefreshTime;

        private void Update()
        {
            if (_player.IsMoving)
            {
                _lastRefreshTime = 0;
                return;
            }

            _lastRefreshTime -= Time.deltaTime;
            _shouldCast = false;

            if (_lastRefreshTime <= 0)
            {
                _shouldCast = true;
                _lastRefreshTime = _refreshRate;
                DoSingleSphereHit(transform.position);

                _player.Target = _target;
            }
        }

        private void DoSingleSphereHit(Vector3 origin)
        {
            if (Physics.CheckSphere(origin, _radius, _layerMask))
            {
                Collider[] hitCollider = Physics.OverlapSphere(origin, _radius, _layerMask);
                if (hitCollider.Length > 0)
                {
                    _target = FindNearestTarget(hitCollider).transform;
                    return;
                }
            }

            _target = null;
        }

        Collider FindNearestTarget(Collider[] targets)
        {
            if (targets == null || targets.Length == 0) return null;

            var target =
                targets
                    .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
                    .FirstOrDefault();

            if (target != null) OnTargetChanget?.Invoke();
            return target;
        }

        void OnDrawGizmos()
        {
            if (_shouldCast)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, _radius);
            }
        }
    }
}