using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ReloadAnimationAction : ITickable, WeaponReloadComponent.IAction,
        WeaponShootComponent.ICondition
    {
        [Inject(Id = WeaponParameterID.ReloadTime)]
        private readonly float _reloadTime;

        private readonly Entity _entity;

        private readonly Animator _animator;
        private bool _reloading;
        private float _timer;

        public ReloadAnimationAction(Animator animator, Entity entity)
        {
            _animator = animator;
            _entity = entity;
        }

        public void Tick()
        {
            if (!_reloading) return;

            _timer -= Time.deltaTime;

            if (_timer <= 0)
                _reloading = false;
        }

        public void StartRealod()
        {
            _reloading = true;
            _timer = _reloadTime;
            _animator.Play("Reload", 1);
        }

        public void FinishReload()
        {
            //_animator.SetTrigger("FinishReload");
        }

        bool WeaponShootComponent.ICondition.Invoke()
        {
            return !_reloading;
        }
    }
}