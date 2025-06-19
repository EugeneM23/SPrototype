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

        // Параметры для виляния
        private float _wiggleAmplitude = 0.4f; // Амплитуда виляния по X
        private float _wiggleFrequency = 11f; // Частота виляния
        private float _wiggleTime; // Время для синуса
        private Vector3 _lastPosition; // Предыдущая позиция для расчета направления

        public BulletProjectileMoveComponent(Entity bullet)
        {
            _bullet = bullet;
        }

        public void Initialize() => _bullet.OnEntityEnable += Reset;

        private void Reset()
        {
            _progress = 0;
            _initialized = false;
            _wiggleTime = 0f;
        }

        public void Move()
        {
            if (!_initialized)
            {
                _startPos = _bullet.transform.position;
                _curveLength = CalculateCurveLength();
                _initialized = true;
                _lastPosition = _startPos;
            }

            float deltaProgress = (_speed * Time.deltaTime) / _curveLength;
            _progress += deltaProgress;
            _wiggleTime += Time.deltaTime;

            // Базовое движение по кривой Безье
            Vector3 midPoint = (_startPos + _targetPos) * 0.5f;
            midPoint.y += 15f;

            float t = _progress;
            float u = 1f - t;
            Vector3 basePos = u * u * _startPos + 2f * u * t * midPoint + t * t * _targetPos;

            // Применяем виляние
            Vector3 finalPos = ApplyWiggle(basePos);

            // Вычисляем направление движения с учетом виляния
            Vector3 direction = (finalPos - _lastPosition).normalized;
            if (direction != Vector3.zero)
            {
                _bullet.transform.rotation = Quaternion.LookRotation(direction);
            }

            _lastPosition = finalPos;
            _bullet.transform.position = finalPos;
        }

        private Vector3 ApplyWiggle(Vector3 basePosition)
        {
            // Вычисляем направление от старта к цели для определения локальных осей
            Vector3 forwardDirection = (_targetPos - _startPos).normalized;
            Vector3 rightDirection = Vector3.Cross(forwardDirection, Vector3.up).normalized;

            // Синусоидальный сдвиг по оси X (перпендикулярно направлению полета)
            float wiggleOffset = Mathf.Sin(_wiggleTime * _wiggleFrequency) * _wiggleAmplitude;

            // Применяем сдвиг перпендикулярно направлению полета
            Vector3 wiggleVector = rightDirection * wiggleOffset;

            return basePosition + wiggleVector;
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

        // Методы для настройки параметров виляния
        public void SetWiggleParameters(float amplitude, float frequency)
        {
            _wiggleAmplitude = amplitude;
            _wiggleFrequency = frequency;
        }

        public void SetSeed(int seed) => _speed = seed;

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            _bullet.transform.SetPositionAndRotation(position, rotation);
        }

        public void SetTargetPos(Vector3 targetPos) => _targetPos = targetPos;
    }
}