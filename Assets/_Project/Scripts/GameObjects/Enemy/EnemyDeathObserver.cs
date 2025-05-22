namespace Gameplay
{
    public class EnemyDeathObserver
    {
        private readonly HealthComponent _health;
        private readonly PushComponent _pushComponent;

        public EnemyDeathObserver(PushComponent pushComponent, HealthComponent health)
        {
            _pushComponent = pushComponent;
            _health = health;
            _health.OnDespawn += _ => ResetComponents();
        }

        private void ResetComponents()
        {
            _pushComponent.Reset();
        }
    }
}