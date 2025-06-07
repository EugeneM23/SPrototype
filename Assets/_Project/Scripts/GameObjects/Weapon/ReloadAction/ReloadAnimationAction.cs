using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ReloadAnimationAction : ITickable, WeaponReloadComponent.IAction,
        WeaponShootComponent.ICondition
    {
        private readonly RangedWeaponConfig _config;

        private readonly Animator _animator;
        private bool _reloading;
        private float _timer;

        public ReloadAnimationAction(Animator animator, RangedWeaponConfig config)
        {
            _animator = animator;
            _config = config;
        }

        public void Tick()
        {
            if (!_reloading) return;

            _timer -= Time.deltaTime;

            if (_timer <= 0)
                _reloading = false;
        }

        public void StartReload()
        {
            _reloading = true;
            _timer = _config.reloadTime;
            _animator.Play("Reload", 1);
        }

        public void FinishReload()
        {
        }

        bool WeaponShootComponent.ICondition.Invoke()
        {
            return !_reloading;
        }
    }
}