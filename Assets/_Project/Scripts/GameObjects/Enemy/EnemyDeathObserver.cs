namespace Gameplay
{
    public class EnemyDeathObserver
    {
        private readonly Entity _health;
        private readonly PushComponent _pushComponent;
        private readonly LootSpawnComponent _lootSpawnComponent;

        public EnemyDeathObserver(PushComponent pushComponent, Entity health, LootSpawnComponent lootSpawnComponent)
        {
            _pushComponent = pushComponent;
            _health = health;
            _lootSpawnComponent = lootSpawnComponent;
            _health.OnDispose += _ => ResetComponents();
            _health.OnDispose += SpawnLoot;
        }

        private void SpawnLoot(Entity enemy)
        {
            _lootSpawnComponent.SpawnLoot(enemy);
        }

        private void ResetComponents()
        {
            _pushComponent.Reset();
        }
    }
}