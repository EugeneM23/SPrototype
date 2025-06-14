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
        private float _timer = 0.05f;
        private bool _canShoot;

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
            _canShoot = false;

            // _leanComponent.Lean();

            if (_characterController.velocity.magnitude > 0.05f)
            {
                _characterConditions.IsChasing = true;
                _characterConditions.IsIdling = false;
                _timer = 0.05f;
            }
            else
            {
                _characterConditions.IsChasing = false;
                _characterConditions.IsIdling = true;
                if (_lookAtComponent.LookAtAndCheck())
                {
                    _timer -= Time.deltaTime;
                    if (_timer < 0)
                    {
                        _canShoot = true;
                    }
                    else
                    {
                        _canShoot = false;
                    }
                }
            }
        }

        public void Shoot()
        {
            if (!_canShoot || _characterController.velocity.magnitude > 0.05f) return;


            OnShoot?.Invoke();
        }
    }
}