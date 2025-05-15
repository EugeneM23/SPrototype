using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class SpawnChargeEffectsComponent : EnemyChargeState.IAction
    {
        private readonly ChargeEffect _chargeEffect;

        public SpawnChargeEffectsComponent(ChargeEffect chargeEffect)
        {
            _chargeEffect = chargeEffect;
        }

        public void EnterActions()
        {
            _chargeEffect.gameObject.SetActive(true);
        }

        public void ExitActions()
        {
            _chargeEffect.gameObject.SetActive(false);
        }
    }
}