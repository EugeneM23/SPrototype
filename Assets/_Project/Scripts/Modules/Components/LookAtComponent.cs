using Gameplay;
using UnityEngine;
using Zenject;

namespace Modules
{
    public class LookAtComponent
    {
        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _root;

        private readonly TargetComponent _targetComponent;
        private readonly CharacterStats _stats;

        public LookAtComponent(TargetComponent targetComponent)
        {
            _targetComponent = targetComponent;
        }

        public bool LookAtAndCheck()
        {
            if (_targetComponent.Target == null || _root == null) return false;

            Vector3 direction = _targetComponent.Target.position - _root.transform.position;
            direction.y = 0f;


            if (direction == Vector3.zero)
                return true;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _root.transform.rotation = Quaternion.RotateTowards(_root.transform.rotation, targetRotation,
                _stats.LookAtSpeed * Time.deltaTime);

            float angle = Quaternion.Angle(_root.transform.rotation, targetRotation);
            bool complite = angle < 0.1f;

            return complite;
        }
    }
}