using Gameplay;
using UnityEngine;
using Zenject;

namespace Modules
{
    public class LookAtComponent
    {
        private readonly TargetComponent _targetComponent;
        private readonly CharacterStats _stats;

        public LookAtComponent(TargetComponent targetComponent, CharacterStats stats)
        {
            _targetComponent = targetComponent;
            _stats = stats;
        }

        public bool LookAtAndCheck()
        {
            if (_targetComponent.Target == null || _stats.CharacterEntity == null) return false;

            Vector3 direction = _targetComponent.Target.position - _stats.CharacterEntity.transform.position;
            direction.y = 0f;


            if (direction == Vector3.zero)
                return true;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _stats.CharacterEntity.transform.rotation = Quaternion.RotateTowards(
                _stats.CharacterEntity.transform.rotation, targetRotation,
                _stats.LookAtSpeed * Time.deltaTime);

            float angle = Quaternion.Angle(_stats.CharacterEntity.transform.rotation, targetRotation);
            bool complite = angle < 0.1f;

            return complite;
        }
    }
}