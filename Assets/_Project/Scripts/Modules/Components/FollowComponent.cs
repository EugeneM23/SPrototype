using UnityEngine;
using Zenject;

namespace Modules
{
    public class FollowComponent : ILateTickable
    {
        private readonly Transform _folowObject;
        private readonly float _smoothTime;

        private Vector3 _offset;
        private Transform _target;

        private Vector3 _velocity = Vector3.zero;

        public FollowComponent(Transform folowObject, float smoothTime)
        {
            _smoothTime = smoothTime;
            _folowObject = folowObject;
        }

        public void Tick()
        {
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            if (_folowObject != null && target != null)
                _offset = _folowObject.position - _target.transform.position;
        }

        public void LateTick()
        {
            if (_target == null || _folowObject == null) return;

            Vector3 targetPosition = _target.transform.position + _offset;
            _folowObject.position =
                Vector3.SmoothDamp(_folowObject.position, targetPosition, ref _velocity, _smoothTime);
        }
    }
}