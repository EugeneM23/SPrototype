using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Gameplay
{
    public class WeaponShootComponent
    {
        public interface ICondition
        {
            bool Invoke();
        }

        public interface IAction
        {
            void Invoke();
        }

        public WeaponShootComponent(List<ICondition> conditions, List<IAction> actions)
        {
            _conditions = conditions;
            _actions = actions;
        }

        private readonly List<ICondition> _conditions;
        private readonly List<IAction> _actions;

        public bool CanShoot()
        {
            return _conditions.All(it => it.Invoke());
        }

        public void Shoot()
        {
            if (!CanShoot()) return;

            foreach (var item in _actions)
                item.Invoke();
        }
    }

    public class WeaponInRangeCondition : WeaponShootComponent.ICondition
    {
        private readonly WeaponSetings _setings;
        private readonly ICharacterProvider _character;

        public WeaponInRangeCondition(WeaponSetings setings, ICharacterProvider character)
        {
            _setings = setings;
            _character = character;
        }

        public bool Invoke()
        {
            float distance = Vector3.Distance(_character.Character.transform.position,
                _character.Character.Get<ICharacter>().Target.transform.position);

            return distance <= _setings.FireRange;
        }
    }
}