using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ReloadAnimationAction : ITickable, WeaponReloadComponent.IAction, WeaponReloadComponent.ICondition,
        WeaponShootComponent.ICondition
    {
        [Inject(Id = WeaponParameterID.ReloadTime)]
        private readonly float _reloadTime;

        private readonly Animator _animator;
        private bool _reloading;
        private float _timer;

        public ReloadAnimationAction(Animator animator)
        {
            _animator = animator;
        }

        public void Tick()
        {
            if (!_reloading) return;

            _timer -= Time.deltaTime;

            if (_timer <= 0)
                _reloading = false;
        }

        public void Invoke()
        {
            _reloading = true;
            _timer = _reloadTime;
            _animator.Play("Reload", 1);

        }

        bool WeaponReloadComponent.ICondition.Invoke()
        {
            return !_reloading;
        }

        bool WeaponShootComponent.ICondition.Invoke()
        {
            return !_reloading;
        }
    }
}