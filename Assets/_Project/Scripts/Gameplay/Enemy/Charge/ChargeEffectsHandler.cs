namespace Gameplay
{
    public class ChargeEffectsHandler : EnemyChargeState.IAction
    {
        private readonly ChargeEffectMarker _chargeEffectMarker;

        public ChargeEffectsHandler(ChargeEffectMarker chargeEffectMarker)
        {
            _chargeEffectMarker = chargeEffectMarker;
        }

        public void EnterActions()
        {
            _chargeEffectMarker.gameObject.SetActive(true);
        }

        public void ExitActions()
        {
        }

        public void ExecuteActions()
        {
            _chargeEffectMarker.gameObject.SetActive(false);
        }
    }
}