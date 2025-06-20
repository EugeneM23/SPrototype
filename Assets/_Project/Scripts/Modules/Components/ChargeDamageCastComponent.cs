using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Gameplay
{
    public class ChargeDamageCastComponent : ITickable, EnemyChargeState.IAction
    {
        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _root;

        private readonly int _damage;
        private readonly float _damageRadius;
        private readonly float _stunTime;
        private readonly Entity _stunEffect;
        private readonly GameFactory _factory;
        private readonly TargetComponent _target;
        private readonly DelayedAction _delayedAction;

        private float _timer;
        private bool _enable;

        public ChargeDamageCastComponent(int damage, float stunTime, Entity stunEffect, float damageRadius,
            GameFactory factory, TargetComponent target, DelayedAction delayedAction)
        {
            _damage = damage;
            _stunTime = stunTime;
            _stunEffect = stunEffect;
            _damageRadius = damageRadius;
            _factory = factory;
            _target = target;
            _delayedAction = delayedAction;
        }

        public void DamageCast(float time)
        {
            _timer = time;
            _enable = true;
        }

        public void ExecuteActions() => DamageCast(_stunTime);

        public void Tick()
        {
            if (!_enable) return;

            _timer -= Time.deltaTime;
            if (_timer <= 0)
                _enable = false;

            if (IsTargetInRange())
            {
                var targetEntity = _target.Target.GetComponent<Entity>();

                ApplyDamageAndDisable(targetEntity);
                CreateStunEffect();
                ScheduleRecoveryActions(targetEntity);
                _enable = false;
            }
        }

        private bool IsTargetInRange()
        {
            var distance = Vector3.Distance(_root.transform.position, _target.Target.position);
            return distance < _damageRadius;
        }

        private void ApplyDamageAndDisable(Entity targetEntity)
        {
            var conditions = targetEntity.Get<CharacterConditions>();
            var animator = targetEntity.Get<Animator>();
            var kernel = targetEntity.GetComponent<GameKarnel>();

            conditions.IsBusy = true;
            animator.Play("Death");
            kernel.enabled = false;
            targetEntity.Get<HealthComponent>().TakeDamage(_damage);
        }

        private void CreateStunEffect()
        {
            var stunEffect = _factory.Create(_stunEffect);
            var stunPosition = _target.Target.transform.position + Vector3.up * 4;
            stunEffect.transform.position = stunPosition;
        }

        private void ScheduleRecoveryActions(Entity targetEntity)
        {
            var conditions = targetEntity.Get<CharacterConditions>();
            var animator = targetEntity.Get<Animator>();
            var kernel = targetEntity.GetComponent<GameKarnel>();

            _delayedAction.Schedule(_stunTime, () => kernel.enabled = true);
            _delayedAction.Schedule(_stunTime, () => animator.Play("Idle"));
            _delayedAction.Schedule(_stunTime, () => conditions.IsBusy = false);
        }

        public void EnterActions()
        {
        }

        public void ExitActions()
        {
        }
    }
}