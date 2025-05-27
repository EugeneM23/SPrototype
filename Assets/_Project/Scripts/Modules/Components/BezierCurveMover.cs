using UnityEngine;

namespace Gameplay
{
    public class BezierCurveMover
    {
        private Vector3 point0;
        private Vector3 point1;
        private Vector3 point2;
        private float curveLength;
        private float height;

        public float Progress { get; private set; } = 0f;
        public bool IsComplete => Progress >= 1f;

        public BezierCurveMover(float height = 10f)
        {
            this.height = height;
        }

        public void Initialize(Vector3 start, Vector3 end)
        {
            point0 = start;
            point2 = end;

            // Контрольная точка по середине, поднятая вверх
            point1 = (point0 + point2) * 0.5f;
            point1.y += height;

            curveLength = CalculateCurveLength();
            Progress = 0f;
        }

        public Vector3 MoveAlongCurve(float speed)
        {
            float deltaProgress = (speed * Time.deltaTime) / curveLength;
            Progress = Mathf.Clamp01(Progress + deltaProgress);
            return GetBezierPoint(Progress);
        }

        private Vector3 GetBezierPoint(float t)
        {
            float u = 1f - t;
            return u * u * point0 + 2f * u * t * point1 + t * t * point2;
        }

        private float CalculateCurveLength()
        {
            float length = 0f;
            Vector3 prev = GetBezierPoint(0f);

            for (int i = 1; i <= 10; i++)
            {
                float t = i / 10f;
                Vector3 current = GetBezierPoint(t);
                length += Vector3.Distance(prev, current);
                prev = current;
            }

            return length;
        }
    }
}