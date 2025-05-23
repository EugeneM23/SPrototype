using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ReloadStatusUI : WeaponReloadComponent.IAction, IInitializable
    {
        [Inject(Id = WeaponParameterID.ReloadStatusUI)]
        private readonly GameObject _prefab;

        [Inject(Id = WeaponParameterID.ReloadTime)]
        private readonly float _reloadTime;

        private DelayedAction _delayedAction;
        private readonly DiContainer _container;
        private GameObject _ui;

        private readonly PlayerCharacterProvider _player;

        public ReloadStatusUI(DelayedAction delayedAction, DiContainer container, PlayerCharacterProvider player)
        {
            _delayedAction = delayedAction;
            _container = container;
            _player = player;
        }

        public void Invoke()
        {
            _ui.SetActive(true);
            _delayedAction.Schedule(_reloadTime, () => _ui.SetActive(false));
        }

        public void Initialize()
        {
            _ui = _container.InstantiatePrefab(_prefab);
            _ui.gameObject.transform.SetParent(_player.Character.transform);
            _ui.transform.localPosition += new Vector3(0, 2, 0);
            _ui.SetActive(false);
        }
    }
}