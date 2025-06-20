using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAttackAssistComponent : ITickable
    {
        private Transform _target;
        private Transform _root;
        private float _speed;
        private float _time;

        private readonly CharacterConditions _conditions;
        private bool _enable;

        public EnemyAttackAssistComponent(CharacterConditions conditions)
        {
            _conditions = conditions;
        }

        public void RotateToTarget(Transform target, Transform enemy, int speed, float time)
        {
            _target = target.transform;
            _root = enemy.transform;
            _speed = speed;
            _time = time;
            _enable = true;
        }

        public void Tick()
        {
            if (!_enable || _target == null || !_conditions.IsAlive) return;

            _time -= Time.deltaTime;
            if (_time > 0)
            {
                Vector3 direction = _target.position - _root.position;

                direction.y = 0;

                if (direction.sqrMagnitude > 0.1f)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
                    _root.rotation = Quaternion.Slerp(_root.rotation, targetRotation, _speed * Time.deltaTime);
                }
            }
            else
            {
                _enable = false;
            }
        }
    }
}