using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MeleeDamageComponent
    {
        private readonly TargetComponent _target;
        private readonly Entity _character;
        private readonly MeleeWeaponConfig _config;

        public MeleeDamageComponent(TargetComponent target,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity character, MeleeWeaponConfig config)
        {
            _target = target;
            _character = character;
            _config = config;
        }

        private void DamageCast()
        {
            if (_target == null) return;

            Vector3 playerPos = _character.transform.position;
            Vector3 targetPos = _target.Target.transform.position;

            float distance = Vector3.Distance(playerPos, targetPos);
            if (distance > _config.range) return;

            Vector3 directionToTarget = (targetPos - playerPos).normalized;
            Vector3 playerForward = _character.transform.forward;
            float angle = Vector3.Angle(playerForward, directionToTarget);

            if (angle > 30) return;

            IDamageable healthComponent = _target.Target.GetComponent<Entity>().Get<IDamageable>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(_config.damage);
            }
        }

        public void DamageCast(string name)
        {
            if (name == "DamageCast")
                DamageCast();
        }
    }
}