namespace Gameplay
{
    public class ChargeRotationHandler : EnemyChargeState.IAction
    {
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly int _rotationSpeed;
        private readonly float _rotationDuration;

        private readonly TargetComponent _targetComponent;
        private readonly Entity _entity;

        public ChargeRotationHandler(
            EnemyAttackAssistComponent assistComponent,
            int rotationSpeed,
            float rotationDuration, TargetComponent targetComponent, Entity entity)
        {
            _assistComponent = assistComponent;
            _rotationSpeed = rotationSpeed;
            _rotationDuration = rotationDuration;
            _targetComponent = targetComponent;
            _entity = entity;
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