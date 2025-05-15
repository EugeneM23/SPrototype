using UnityEngine;

namespace Modules
{
    public class LeanComponent
    {
        private readonly Transform _target;
        private readonly float leanAmount = 20f;
        private readonly float leanSpeed = 7f;

        private Vector3 lastForward;
        private float currentLean = 0f;

        public LeanComponent(Transform target) => _target = target;

        public void Lean()
        {
            Vector3 currentForward = _target.forward;
            Vector3 cross = Vector3.Cross(lastForward, currentForward);
            float angle = Vector3.SignedAngle(lastForward, currentForward, Vector3.up);
            float angularSpeed = angle / Time.deltaTime;

            float targetLean = Mathf.Clamp(-angularSpeed / 200f * leanAmount, -leanAmount, leanAmount);

            currentLean = Mathf.Lerp(currentLean, targetLean, Time.deltaTime * leanSpeed);

            Quaternion leanRotation = Quaternion.Euler(0f, 0f, currentLean);
            _target.localRotation = Quaternion.Euler(0f, _target.eulerAngles.y, 0f) * leanRotation;

            lastForward = currentForward;
        }
    }
}