using System;
using UnityEngine;

namespace Gameplay
{
    public class PlayerTransformold : MonoBehaviour
    {
        public float Speed { get; private set; }

        private float _timer;
        private Vector3 originPosition;
        private Vector3 lastPosition;
        private Quaternion lastRotation;

        void Start()
        {
            lastPosition = transform.position;
            lastRotation = transform.rotation;
        }

        void Update() => Speed = GetCharacterSpeed();

        private float GetCharacterSpeed()
        {
            Vector3 deltaPosition = transform.position - lastPosition;
            float linearSpeed = deltaPosition.magnitude / Time.deltaTime;

            Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(lastRotation);

            deltaRotation.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);
            if (angleInDegrees > 180f)
                angleInDegrees -= 360f;

            float angularSpeed = Mathf.Abs(angleInDegrees) / Time.deltaTime;

            lastPosition = transform.position;
            lastRotation = transform.rotation;

            return Math.Max(0, linearSpeed - angularSpeed * 0.1f);
        }
    }
}