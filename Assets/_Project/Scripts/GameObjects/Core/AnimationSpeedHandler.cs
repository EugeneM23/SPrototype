using UnityEngine;

namespace Gameplay
{
    public class AnimationSpeedHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _runSpeed = 1;
        [SerializeField] private float _wealkSpeed = 1;

        private void OnEnable()
        {
            _animator.SetFloat("RunSpeed", _runSpeed);
            _animator.SetFloat("WalkSpeed", _wealkSpeed);
        }
    }
}