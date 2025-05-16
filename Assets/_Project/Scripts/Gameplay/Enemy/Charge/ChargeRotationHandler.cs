namespace Gameplay
{
    public class ChargeRotationHandler : EnemyChargeState.IAction
    {
        private readonly EnemyBlackBoard _blackBoard;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly int _rotationSpeed;
        private readonly float _rotationDuration;

        public ChargeRotationHandler(
            EnemyBlackBoard blackBoard,
            EnemyAttackAssistComponent assistComponent,
            int rotationSpeed,
            float rotationDuration)
        {
            _blackBoard = blackBoard;
            _assistComponent = assistComponent;
            _rotationSpeed = rotationSpeed;
            _rotationDuration = rotationDuration;
        }

        public void EnterActions()
        {
            _assistComponent.RotateToTarget(_blackBoard.Target, _blackBoard.Enemy, _rotationSpeed, _rotationDuration);
        }

        public void ExitActions()
        {
        }

        public void ExecuteActions()
        {
        }
    }
}