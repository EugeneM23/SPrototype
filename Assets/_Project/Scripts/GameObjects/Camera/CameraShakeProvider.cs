using System;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace Gameplay
{
    public class CameraShakeProvider : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [Inject] private readonly CameraShaker _cameraShaker;

        private void Start()
        {
            _cameraShaker.OnShoot += PlayerShoot;
            _cameraShaker.Onexplosion += Explosion;
            _cameraShaker.OnSmallShake += SmallShake;
        }

        private void Explosion()
        {
            _animator.SetTrigger("Explosion");
        }

        private void SmallShake()
        {
            _animator.SetTrigger("SmallShake");
        }

        private void PlayerShoot()
        {
            _animator.SetTrigger("Shoot");
        }
    }
}