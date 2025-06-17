using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponShootComponent
    {
        private readonly TargetComponent _targetComponent;

        public interface ICondition
        {
            bool Invoke();
        }

        public interface IAction
        {
            void Invoke();
        }

        [Inject] private readonly List<ICondition> _conditions;
        [Inject] private readonly List<IAction> _actions;

        public WeaponShootComponent(TargetComponent targetComponent)
        {
            _targetComponent = targetComponent;
        }

        public bool CanShoot()
        {
            return _conditions.All(it => it.Invoke());
        }

        public void Shoot()
        {
            Debug.Log(_targetComponent.Target.name);
            if (!CanShoot()) return;

            foreach (var item in _actions)
                item.Invoke();
        }
    }
}