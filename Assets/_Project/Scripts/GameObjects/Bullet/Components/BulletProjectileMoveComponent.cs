using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletProjectileMoveComponent : IBulletMoveComponent, IInitializable
    {
        private readonly Entity bullet;
        private Vector3 _startPos;
        private Vector3 _targetPos;
        private float _speed;
        private float progress;
        private bool initialized;
        private float curveLength;

        public BulletProjectileMoveComponent(Entity bullet)
        {
            this.bullet = bullet;
        }

        public void Initialize() => bullet.OnEntityEnable += Reset;

        private void Reset()
        {
            progress = 0;
            initialized = false;
        }

        public void Move()
        {
            if (!initialized)
            {
                _startPos = bullet.transform.position;
                curveLength = CalculateCurveLength();
                initialized = true;
            }

            float deltaProgress = (_speed * Time.deltaTime) / curveLength;
            progress += deltaProgress;


            Vector3 midPoint = (_startPos + _targetPos) * 0.5f;
            midPoint.y += 10f;

            float t = progress;
            float u = 1f - t;
            Vector3 newPos = u * u * _startPos + 2f * u * t * midPoint + t * t * _targetPos;

            bullet.transform.position = newPos;
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

        public void SetTargetPos(Vector3 targetPos) => _targetPos = targetPos;
    }
}