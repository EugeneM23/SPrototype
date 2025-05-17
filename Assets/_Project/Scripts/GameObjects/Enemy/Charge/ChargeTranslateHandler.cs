using UnityEngine;

namespace Gameplay
{
    public class ChargeTranslateHandler : EnemyChargeState.IAction
    {
        private readonly ChargeRaySensor _chargeRaySensor;
        private readonly TranslateComponent _translateComponent;
        private Vector3 _targetPosition;

        private readonly float _chargeDuration;
        private readonly float _chargeSpeed;

        private bool _hasStarted;

        public ChargeTranslateHandler(
            TranslateComponent translateComponent,
            float chargeDuration,
            float chargeSpeed, ChargeRaySensor chargeRaySensor)
        {
            _translateComponent = translateComponent;
            _chargeDuration = chargeDuration;
            _chargeSpeed = chargeSpeed;
            _chargeRaySensor = chargeRaySensor;
        }

        public void EnterActions()
        {
            _hasStarted = false;
        }

        public void ExitActions()
        {
        }

        public void ExecuteActions()
        {
            if (!_hasStarted)
            {
                _targetPosition = _chargeRaySensor.CastRay();
                _translateComponent.Translate(_targetPosition, _chargeDuration, _chargeSpeed);
                _hasStarted = true;
            }
        }
    }
}