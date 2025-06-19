using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ProtectionSieldView : MonoBehaviour, EnemyChargeState.IAction, EnemyMeleeAttackState.IAction
    {
        [Inject] private readonly HealthComponent _healthComponent;

        private void OnEnable() => _healthComponent.OnDead += _ => gameObject.SetActive(false);

        void EnemyChargeState.IAction.EnterActions() => gameObject.SetActive(false);

        void EnemyChargeState.IAction.ExitActions() => gameObject.SetActive(true);

        void EnemyChargeState.IAction.ExecuteActions()
        {
        }

        void EnemyMeleeAttackState.IAction.EnterAction() => gameObject.SetActive(false);

        public void ExitAction() => gameObject.SetActive(true);
    }
}