using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ReloadStatusUI : MonoBehaviour, WeaponReloadComponent.IAction
    {
        [Inject(Id = WeaponParameterID.ReloadTime)]
        private readonly float _reloadTime;

        private DelayedAction _delayedAction;

        private PlayerCharacterProvider _player;

        [Inject]
        public void Counstruct(DelayedAction delayedAction, DiContainer container, PlayerCharacterProvider player)
        {
            _delayedAction = delayedAction;
            _player = player;
        }

        public void Invoke()
        {
            transform.gameObject.SetActive(true);
            _delayedAction.Schedule(_reloadTime, () => transform.gameObject.SetActive(false));
        }

        private void Start()
        {
            transform.SetParent(_player.Character.transform);
            transform.localPosition += new Vector3(0, 2, 0);
            transform.gameObject.SetActive(false);
        }
    }
}