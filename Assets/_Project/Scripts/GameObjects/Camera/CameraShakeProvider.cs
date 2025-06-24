using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CameraShakeProvider : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [Inject] private readonly CameraShaker _cameraShaker;

        private void Start()
        {
            _cameraShaker.OnShoot += PlayerShoot;
        }

        private void PlayerShoot()
        {
            _animator.SetTrigger("Shoot");
        }
    }
}