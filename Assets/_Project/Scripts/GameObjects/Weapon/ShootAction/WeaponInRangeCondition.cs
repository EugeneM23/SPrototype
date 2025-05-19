using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponInRangeCondition : WeaponShootComponent.ICondition
    {
        [Inject(Id = WeaponParameterID.FireRange)]
        private float _fireRange;

        private readonly ICharacterProvider _character;

        public WeaponInRangeCondition(ICharacterProvider character)
        {
            _character = character;
        }

        public bool Invoke()
        {
            float distance = Vector3.Distance(_character.Character.transform.position,
                _character.Character.Get<ICharacter>().Target.transform.position);

            return distance <= _fireRange;
        }
    }
}