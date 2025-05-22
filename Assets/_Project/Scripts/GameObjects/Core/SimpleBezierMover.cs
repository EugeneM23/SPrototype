using UnityEngine;

namespace Gameplay
{
    public class SimpleBezierMover : MonoBehaviour
    {
        public Transform[] points = new Transform[3];
        public float speed = 5f;

        private float progress = 0f;

        void Update()
        {
            progress += speed * Time.deltaTime * 0.2f;
            progress = Mathf.Clamp01(progress);

            transform.position = GetBezierPoint(progress);
        }

        Vector3 GetBezierPoint(float t)
        {
            float u = 1f - t;
            return u * u * points[0].position +
                   2f * u * t * points[1].position +
                   t * t * points[2].position;
        }

        void OnDrawGizmos()
        {
            if (points[0] == null || points[1] == null || points[2] == null)
                return;

            Gizmos.color = Color.white;
            Vector3 prevPoint = GetBezierPoint(0f);

            for (int i = 1; i <= 20; i++)
            {
                float t = i / 20f;
                Vector3 currentPoint = GetBezierPoint(t);
                Gizmos.DrawLine(prevPoint, currentPoint);
                prevPoint = currentPoint;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(points[0].position, 0.1f);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(points[1].position, 0.1f);
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(points[2].position, 0.1f);

            // Текущая позиция объекта
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 0.15f);
        }
    }
}