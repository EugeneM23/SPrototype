namespace Gameplay
{
    public class EnemyDeathObserver
    {
        private readonly HealthComponentBase _healthComponent;
        private readonly PushComponent _pushComponent;

        public EnemyDeathObserver(HealthComponentBase healthComponent, PushComponent pushComponent)
        {
            _healthComponent = healthComponent;
            _pushComponent = pushComponent;
            _healthComponent.OnDespawnTest += _ => ResetComponents();
        }

        private void ResetComponents()
        {
            _pushComponent.Reset();
        }
    }
}