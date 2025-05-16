namespace Gameplay
{
    public class ChargeDamageCastHandler : EnemyChargeState.IAction
    {
        private readonly DamageCastParams _damageCast;
        private readonly DamageCasterManager _damageCasterManager;

        public ChargeDamageCastHandler(DamageCastParams damageCast, DamageCasterManager damageCasterManager)
        {
            _damageCast = damageCast;
            _damageCasterManager = damageCasterManager;
        }

        public void EnterActions()
        {
        }

        public void ExitActions()
        {
        }

        public void ExecuteActions()
        {
            _damageCasterManager.CastDamage(_damageCast);
        }
    }
}