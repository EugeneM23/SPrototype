using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponReloadComponent : ITickable
    {
        public interface ICondition
        {
            bool Invoke();
        }

        public interface IAction
        {
            void Invoke();
        }

        private readonly List<ICondition> _conditions;
        private readonly List<IAction> _actions;
        private readonly WeaponClipComponent _clip;
        private readonly DelayedAction _delayedAction;

        [Inject(Id = WeaponParameterID.ReloadTime)]
        private readonly float _reloadTime;

        public WeaponReloadComponent(List<ICondition> conditions, List<IAction> actions,
            WeaponClipComponent clip, DelayedAction delayedAction)
        {
            _conditions = conditions;
            _actions = actions;
            _clip = clip;
            _delayedAction = delayedAction;
        }

        public void Tick()
        {
            if (_clip.CurrentCapacity <= 0 && _clip.BulletCount > 0 && CanReload())
            {
                Debug.Log("Reload");
                Reload();
            }
        }

        public bool CanReload()
        {
            return _conditions.All(it => it.Invoke());
        }

        public void Reload()
        {
            if (!CanReload()) return;

            _delayedAction.Schedule(_reloadTime, _clip.Reload);
            foreach (var item in _actions)
                item.Invoke();
        }
    }
}