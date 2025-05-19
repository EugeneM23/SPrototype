using System;
using System.Collections.Generic;
using System.Linq;
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

        [InjectLocal] private readonly List<ICondition> _conditions;

        [InjectLocal] private readonly List<IAction> _actions;

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