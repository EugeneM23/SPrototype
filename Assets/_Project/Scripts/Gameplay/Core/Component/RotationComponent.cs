using UnityEngine;

namespace Modules
{
    public class RotationComponent
    {
        private readonly Transform _target;
        private readonly float _speed;

        public RotationComponent(Transform target, float speed)
        {
            _target = target;
            _speed = speed;
        }

        public void Ratation(Vector3 direction)
        {
            if (direction.sqrMagnitude > 0.001f)
            {
                direction.Normalize();

                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

                _target.rotation =
                    Quaternion.Slerp(_target.rotation, targetRotation, _speed * Time.deltaTime);
            }
        }
    }
}