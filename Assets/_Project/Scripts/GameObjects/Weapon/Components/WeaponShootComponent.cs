using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

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