using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletProjectileMoveComponent : IBulletMoveComponent, IInitializable
    {
        private readonly Entity _bullet;
        private Vector3 _startPos;
        private Vector3 _targetPos;
        private float _speed;
        private float _progress;
        private bool _initialized;
        private float _curveLength;

        public BulletProjectileMoveComponent(Entity bullet)
        {
            _bullet = bullet;
        }

        public void Initialize() => _bullet.OnEntityEnable += Reset;

        private void Reset()
        {
            _progress = 0;
            _initialized = false;
        }

        public void Move()
        {
            if (!_initialized)
            {
                _startPos = _bullet.transform.position;
                _curveLength = CalculateCurveLength();
                _initialized = true;
            }

            float deltaProgress = (_speed * Time.deltaTime) / _curveLength;
            _progress += deltaProgress;

            Vector3 midPoint = (_startPos + _targetPos) * 0.5f;
            midPoint.y += 12f;

            float t = _progress;
            float u = 1f - t;
            Vector3 newPos = u * u * _startPos + 2f * u * t * midPoint + t * t * _targetPos;

            // Вычисляем направление движения
            Vector3 direction = (newPos - _bullet.transform.position).normalized;
            if (direction != Vector3.zero)
            {
                _bullet.transform.rotation = Quaternion.LookRotation(direction);
            }

            _bullet.transform.position = newPos;
        }

        private float CalculateCurveLength()
        {
            Vector3 midPoint = (_startPos + _targetPos) * 0.5f;
            midPoint.y += 10f;

            float length = 0f;
            Vector3 prev = _startPos;

            for (int i = 1; i <= 10; i++)
            {
                float t = i / 10f;
                float u = 1f - t;
                Vector3 current = u * u * _startPos + 2f * u * t * midPoint + t * t * _targetPos;
                length += Vector3.Distance(prev, current);
                prev = current;
            }

            return length;
        }

        public void SetSeed(int seed) => _speed = seed;

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            _bullet.transform.SetPositionAndRotation(position, rotation);
        }

        public void SetTargetPos(Vector3 targetPos) => _targetPos = targetPos;
    }
}