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

        public void DamageCast(string name)
        {
            if (name == "DamageCast")
                DamageCast();
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

            if (angle > 45) return;

            Debug(playerForward, playerPos);


            IDamageable healthComponent = _target.Target.GetComponent<Entity>().Get<IDamageable>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(_config.damage);
            }
        }

        private void Debug(Vector3 playerForward, Vector3 playerPos)
        {
            Vector3 leftBoundary = Quaternion.AngleAxis(-45f, Vector3.up) * playerForward;
            Vector3 rightBoundary = Quaternion.AngleAxis(45f, Vector3.up) * playerForward;
            UnityEngine.Debug.DrawRay(playerPos, leftBoundary * _config.range, Color.red, 2);
            UnityEngine.Debug.DrawRay(playerPos, rightBoundary * _config.range, Color.red, 2);
        }
    }
}