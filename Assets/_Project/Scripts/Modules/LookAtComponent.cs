using Gameplay;
using UnityEngine;

namespace Modules
{
    public class LookAtComponent
    {
        private readonly Transform _root;
        private readonly float _aimingSpeed;
        private readonly TargetComponent _targetComponent;

        public LookAtComponent(Transform root, float aimingSpeed, TargetComponent targetComponent)
        {
            _root = root;
            _aimingSpeed = aimingSpeed;
            _targetComponent = targetComponent;
        }

        public bool LookAtAndCheck()
        {
            if (_targetComponent.Target == null || _root == null) return false;
            
            Vector3 direction = _targetComponent.Target.position - _root.position;
            direction.y = 0f;


            if (direction == Vector3.zero)
                return true;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _root.rotation = Quaternion.RotateTowards(_root.rotation, targetRotation,
                _aimingSpeed * Time.deltaTime);

            float angle = Quaternion.Angle(_root.rotation, targetRotation);
            bool complite = angle < 1f;

            return complite;
        }
    }
}