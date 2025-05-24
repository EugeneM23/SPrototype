using Zenject;

namespace Gameplay
{
    public class ChargeRotationHandler : EnemyChargeState.IAction
    {
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly int _rotationSpeed;
        private readonly float _rotationDuration;

        private readonly TargetComponent _targetComponent;

        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _entity;

        public ChargeRotationHandler(
            EnemyAttackAssistComponent assistComponent,
            int rotationSpeed,
            float rotationDuration, TargetComponent targetComponent)
        {
            _assistComponent = assistComponent;
            _rotationSpeed = rotationSpeed;
            _rotationDuration = rotationDuration;
            _targetComponent = targetComponent;
        }

        public void EnterActions()
        {
            _assistComponent.RotateToTarget(_targetComponent.Target, _entity.transform, _rotationSpeed,
                _rotationDuration);
        }

        public void ExitActions()
        {
        }

        public void ExecuteActions()
        {
        }
    }
}