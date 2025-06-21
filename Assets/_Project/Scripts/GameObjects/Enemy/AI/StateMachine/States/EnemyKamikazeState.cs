using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyKamikazeState : IState
    {
        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _entity;

        private readonly int _impulsePower;
        private readonly float _impulseDuration;
        private readonly TargetComponent _targetComponent;
        private readonly int _damage;

        public EnemyKamikazeState(TargetComponent targetComponent, int damage, int impulsePower, float impulseDuration)
        {
            _targetComponent = targetComponent;
            _damage = damage;
            _impulsePower = impulsePower;
            _impulseDuration = impulseDuration;
        }

        public void Enter()
        {
            _targetComponent.Target.GetComponent<Entity>().Get<HealthComponent>().TakeDamage(_damage);
            _targetComponent.Target.GetComponent<Entity>().Get<PlayerImpulseComponent>()
                .ApplyImpulse(_entity.transform.forward * _impulsePower, _impulseDuration);
            _entity.Get<HealthComponent>().Death();
        }

        public void Update(float deltaTime)
        {
        }

        public void Exit()
        {
        }
    }
}