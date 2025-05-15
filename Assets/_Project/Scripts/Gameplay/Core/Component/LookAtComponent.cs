using UnityEngine;

namespace Modules
{
    public class LookAtComponent
    {
        private readonly Transform _target;
        private readonly float _aimingSpeed;

        public LookAtComponent(Transform target, float aimingSpeed)
        {
            _target = target;
            _aimingSpeed = aimingSpeed;
        }

        public bool LookAtAndCheck(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - _target.position;
            direction.y = 0f;

            if (direction == Vector3.zero)
                return true;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _target.rotation = Quaternion.RotateTowards(_target.rotation, targetRotation,
                _aimingSpeed * Time.deltaTime);

            float angle = Quaternion.Angle(_target.rotation, targetRotation);
            bool complite = angle < 1f;

            return complite;
        }
    }
}