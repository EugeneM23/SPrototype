namespace Gameplay
{
    public class EnemyDeathObserver
    {
        private readonly TakeDamageComponent _takeDamage;
        private readonly PushComponent _pushComponent;

        public EnemyDeathObserver(PushComponent pushComponent, TakeDamageComponent takeDamage)
        {
            _pushComponent = pushComponent;
            _takeDamage = takeDamage;
            _takeDamage.OnDespawn += _ => ResetComponents();
        }

        private void ResetComponents()
        {
            _pushComponent.Reset();
        }
    }
}