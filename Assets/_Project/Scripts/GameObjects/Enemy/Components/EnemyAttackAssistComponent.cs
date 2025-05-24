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

        public void RotateToTarget(Transform target, Transform enemy, int speed, float time)
        {
            _target = target.transform;
            _root = enemy.transform;
            _speed = speed;
            _time = time;
        }

        public void Tick()
        {
            if (_target == null) return;
            
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
        }
    }
}