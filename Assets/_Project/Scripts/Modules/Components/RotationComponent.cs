using Gameplay;
using UnityEngine;
using Zenject;

namespace Modules
{
    public class RotationComponent
    {
        private readonly CharacterStats _stats;

        public RotationComponent(CharacterStats stats)
        {
            _stats = stats;
        }

        public void Ratation(Vector3 direction)
        {
            if (direction.sqrMagnitude > 0.001f)
            {
                direction.Normalize();

                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

                _stats.CharacterEntity.transform.rotation =
                    Quaternion.Slerp(_stats.CharacterEntity.transform.rotation, targetRotation,
                        _stats.RotationSpeed * Time.deltaTime);
            }
        }
    }
}