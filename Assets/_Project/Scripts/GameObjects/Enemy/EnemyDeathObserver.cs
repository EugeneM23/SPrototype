namespace Gameplay
{
    public class EnemyDeathObserver
    {
        private readonly Entity _health;
        private readonly PushComponent _pushComponent;

        public EnemyDeathObserver(PushComponent pushComponent, Entity health)
        {
            _pushComponent = pushComponent;
            _health = health;
            _health.OnDispose += _ => ResetComponents();
        }

        private void ResetComponents()
        {
            _pushComponent.Reset();
        }
    }
}