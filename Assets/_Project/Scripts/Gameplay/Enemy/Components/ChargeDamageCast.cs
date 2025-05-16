using UnityEngine;

namespace Gameplay
{
    public class AnimationChargeComponent : EnemyChargeState.IAction
    {
        private readonly Animator _animator;

        public AnimationChargeComponent(Animator animator)
        {
            _animator = animator;
        }

        public void EnterActions()
        {
            _animator.Play("Charge");
        }

        public void ExitActions()
        {
        }
    }

    public class ChargeDamageCast : EnemyChargeState.IAction
    {
        private readonly DamageCastParams _damageCast;
        private readonly DamageCasterManager _damageCasterManager;

        public ChargeDamageCast(DamageCastParams damageCast, DamageCasterManager damageCasterManager)
        {
            _damageCast = damageCast;
            _damageCasterManager = damageCasterManager;
        }

        public void EnterActions()
        {
        }

        public void ExitActions()
        {
            _damageCasterManager.CastDamage(_damageCast);
        }
    }
}