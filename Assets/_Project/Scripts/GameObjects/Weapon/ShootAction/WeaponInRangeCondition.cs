using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponInRangeCondition : WeaponShootComponent.ICondition
    {
        private readonly WeaponConfig _config;
        private readonly ICharacterProvider _character;

        public WeaponInRangeCondition(ICharacterProvider character, WeaponConfig config)
        {
            _character = character;
            _config = config;
        }

        public bool Invoke()
        {
            var target = _character.Character.Get<TargetComponent>().Target;
            if (target == null) return false;

            float distance = Vector3.Distance(_character.Character.transform.position, target.position);
            return distance <= _config.range;
        }
    }
}