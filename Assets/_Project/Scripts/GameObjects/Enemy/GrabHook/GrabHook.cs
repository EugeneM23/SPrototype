using System;
using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GrabHook : MonoBehaviour, EnemyGrabHookState.IAction
    {
        public event Action OnGrab;
        [SerializeField] private BoxCollider _boxCollider;
        [Inject] private readonly TargetComponent _targetComponent;

        private bool _enable;
        private float _time;

        private void Update()
        {
            if (!_enable) return;

            _time -= Time.deltaTime;

            float distace = Vector3.Distance(_targetComponent.Target.position, gameObject.transform.position);

            if (distace < 4 && _time > 0f)
            {
                OnGrab?.Invoke();
                _targetComponent.Target.transform.position = transform.position;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        public void EnterActions()
        {
        }

        public void ExitActions()
        {
            _enable = false;
        }

        public void ExecuteActions()
        {
            _time = 0.5f;
            _enable = true;
            gameObject.SetActive(true);
        }
    }
}