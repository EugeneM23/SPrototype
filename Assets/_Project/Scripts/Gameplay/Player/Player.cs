using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Player : ITickable, ICharacter
    {
        public event Action OnShoot;
        public Transform Target { get; set; }

        public int Damage { get; }

        private readonly CharacterController _characterController;
        private readonly LookAtComponent _lookAtComponent;
        private readonly LeanComponent _leanComponent;
        public bool IsMoving => GetVelocity() != Vector3.zero;

        public Player(
            CharacterController characterController,
            LookAtComponent lookAtComponent,
            LeanComponent leanComponent)
        {
            _characterController = characterController;
            _lookAtComponent = lookAtComponent;
            _leanComponent = leanComponent;
        }

        public void Tick()
        {
            _leanComponent.Lean();

            if (IsMoving || Target == null) return;

            if (_lookAtComponent.LookAtAndCheck(Target.position))
                Shoot();
        }

        public void Shoot() => OnShoot?.Invoke();

        public Vector3 GetVelocity() => _characterController.velocity;
    }
}