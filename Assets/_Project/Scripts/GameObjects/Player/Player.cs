using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Player : ITickable, IShootable
    {
        public event Action OnShoot;

        private readonly CharacterController _characterController;
        private readonly LookAtComponent _lookAtComponent;
        private readonly LeanComponent _leanComponent;

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

            if (_characterController.velocity != Vector3.zero) return;

            if (_lookAtComponent.LookAtAndCheck())
                OnShoot?.Invoke();
        }
    }
}