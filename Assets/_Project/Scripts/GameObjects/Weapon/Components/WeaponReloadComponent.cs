using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponReloadComponent : ITickable, IInitializable
    {
        public interface ICondition
        {
            bool Invoke();
        }

        public interface IAction
        {
            void StartRealod();
            void FinishReload();
        }

        private readonly List<ICondition> _conditions;
        private readonly List<IAction> _actions;
        private readonly WeaponClipComponent _clip;
        private readonly Entity _weaponEntity;
        private readonly Inventory _inventory;

        [Inject(Id = WeaponParameterID.ReloadTime)]
        private readonly float _reloadTime;

        private float _reloadTimer;
        private bool _isReloading;

        public WeaponReloadComponent(List<ICondition> conditions, List<IAction> actions, WeaponClipComponent clip,
            Entity weaponEntity, Inventory inventory)
        {
            _conditions = conditions;
            _actions = actions;
            _clip = clip;
            _weaponEntity = weaponEntity;
            _inventory = inventory;
        }

        public event Action OnReload;

        public void Initialize() => _weaponEntity.OnEntityDisable += () => _isReloading = false;

        public void Tick()
        {
            if (_isReloading)
            {
                _reloadTimer -= Time.deltaTime;
                if (_reloadTimer <= 0)
                {
                    foreach (var item in _actions)
                        item.FinishReload();

                    _clip.Reload();
                    _isReloading = false;
                }

                return;
            }


            if (_clip.CurrentCapacity <= 0 && _inventory.BulletCount > 0 && CanReload())
                StartReload();
        }

        public bool CanReload()
        {
            return _conditions.All(it => it.Invoke());
        }

        public void StartReload()
        {
            _reloadTimer = _reloadTime;
            _isReloading = true;
            foreach (var item in _actions)
                item.StartRealod();
        }
    }
}