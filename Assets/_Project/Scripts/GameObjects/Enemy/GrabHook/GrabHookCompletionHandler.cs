using Gameplay.Installers;

namespace Gameplay
{
    public class GrabHookCompletionHandler : EnemyGrabHookState.IAction
    {
        private readonly CharacterConditions _conditions;
        private readonly DelayedAction _delayedAction;
        private readonly float _chargeDuration;
        private bool _isScheduled;

        public GrabHookCompletionHandler(CharacterConditions conditions, DelayedAction delayedAction,
            float chargeDuration)
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
                _delayedAction.Schedule(_chargeDuration, () => _conditions.IsBusy = false);
                _isScheduled = true;
            }
        }
    }
}