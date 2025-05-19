namespace Gameplay
{
    public class ChargeCompletionHandler : EnemyChargeState.IAction
    {
        private readonly EnemyBlackBoard _blackBoard;
        private readonly DelayedAction _delayedAction;
        private readonly float _chargeDuration;
        private bool _isScheduled;

        public ChargeCompletionHandler(EnemyBlackBoard blackBoard, DelayedAction delayedAction, float chargeDuration)
        {
            _blackBoard = blackBoard;
            _delayedAction = delayedAction;
            _chargeDuration = chargeDuration;
            _isScheduled = false;
        }

        public void EnterActions()
        {
            _isScheduled = false;
        }

        public void ExitActions()
        {
        }

        public void ExecuteActions()
        {
            if (!_isScheduled)
            {
                _delayedAction.Schedule(0.5f, () => _blackBoard.IsBusy = false);
                _isScheduled = true;
            }
        }
    }
}