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
        private readonly CharacterConditions _characterConditions;

        public Player(
            CharacterController characterController,
            LookAtComponent lookAtComponent,
            LeanComponent leanComponent,
            CharacterConditions characterConditions
        )
        {
            _characterController = characterController;
            _lookAtComponent = lookAtComponent;
            _leanComponent = leanComponent;
            _characterConditions = characterConditions;
        }

        public void Tick()
        {
            _leanComponent.Lean();

            if (_characterController.velocity != Vector3.zero)
            {
                _characterConditions.IsChasing = true;
                _characterConditions.IsAdling = false;
            }
            else
            {
                _characterConditions.IsChasing = false;
                _characterConditions.IsAdling = true;

                if (_lookAtComponent.LookAtAndCheck())
                    OnShoot?.Invoke();
            }
        }
    }
}