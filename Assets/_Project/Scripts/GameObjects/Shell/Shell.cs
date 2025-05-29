using UnityEngine;

namespace Gameplay
{
    public class Shell : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private int _lifeTime = 2;

        private Vector3 _impulseVector3;

        public void SetImpulse(Vector3 impulseVecctor, float power)
        {
            _rb.linearVelocity = Vector3.zero;

            Vector3 worldImpulse = transform.TransformDirection(impulseVecctor);

            _rb.AddForce(worldImpulse * power, ForceMode.Impulse);
            _rb.AddTorque(transform.position * 40, ForceMode.Impulse);
        }
    }
}