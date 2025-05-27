using Gameplay;
using UnityEngine;
using Zenject;

namespace Modules
{
    public class RotationComponent
    {
        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _target;

        private readonly float _speed;

        public RotationComponent(float speed)
        {
            _speed = speed;
        }

        public void Ratation(Vector3 direction)
        {
            if (direction.sqrMagnitude > 0.001f)
            {
                direction.Normalize();

                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

                _target.transform.rotation =
                    Quaternion.Slerp(_target.transform.rotation, targetRotation, _speed * Time.deltaTime);
            }
        }
    }
}