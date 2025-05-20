namespace Gameplay
{
    public class ChargeCompletionHandler : EnemyChargeState.IAction
    {
        private readonly EnemyConditions _conditions;
        private readonly DelayedAction _delayedAction;
        private readonly float _chargeDuration;
        private bool _isScheduled;

        public ChargeCompletionHandler(EnemyConditions conditions, DelayedAction delayedAction, float chargeDuration)
        {
            _conditions = conditions;
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
                _delayedAction.Schedule(0.5f, () => _conditions.IsBusy = false);
                _isScheduled = true;
            }
        }
    }
}