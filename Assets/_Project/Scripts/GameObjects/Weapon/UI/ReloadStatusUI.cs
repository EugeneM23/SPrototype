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
        private Entity _entity;

        [Inject]
        public void Counstruct(DelayedAction delayedAction, DiContainer container, PlayerCharacterProvider player,
            Entity entity)
        {
            _delayedAction = delayedAction;
            _player = player;
            _entity = entity;
        }

        private void OnEnable()
        {
            _entity.OnEntityDisable += () => gameObject.SetActive(false);
        }


        public void StartRealod()
        {
            transform.gameObject.SetActive(true);
        }

        public void FinishReload()
        {
            transform.gameObject.SetActive(false);
        }

        private void Start()
        {
            _entity.Get<WeaponReloadComponent>().OnReload += () => gameObject.SetActive(false);
            transform.SetParent(_player.Character.transform);
            transform.localPosition += new Vector3(0, 2, 0);
        }
    }
}