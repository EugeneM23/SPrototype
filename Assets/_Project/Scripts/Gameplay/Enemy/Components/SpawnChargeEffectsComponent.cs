using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class SpawnChargeEffectsComponent : EnemyChargeState.IAction
    {
        private readonly ChargeEffectMarker _chargeEffectMarker;

        public SpawnChargeEffectsComponent(ChargeEffectMarker chargeEffectMarker)
        {
            _chargeEffectMarker = chargeEffectMarker;
        }

        public void EnterActions()
        {
            _chargeEffectMarker.gameObject.SetActive(true);
        }

        public void ExitActions()
        {
            _chargeEffectMarker.gameObject.SetActive(false);
        }
    }
}