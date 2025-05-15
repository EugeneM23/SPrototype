using System;
using System.Collections.Generic;
using System.Linq;
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
}