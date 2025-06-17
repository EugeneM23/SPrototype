using System;

namespace Gameplay
{
    public class EnemyDeathObserver
    {
        private readonly Entity _enemy;
        private readonly LootSpawnComponent _lootSpawnComponent;
        private readonly PlayerCharacterProvider _player;

        public EnemyDeathObserver(Entity enemy, LootSpawnComponent lootSpawnComponent, PlayerCharacterProvider player)
        {
            _enemy = enemy;
            _lootSpawnComponent = lootSpawnComponent;
            _player = player;
            _enemy.Get<HealthComponent>().OnDead += SpawnLoot;
        }

        private void SpawnLoot(Entity enemy)
        {
            var weapon = _player.Character.Get<PlayerWeaponManager>().CurrentWeapon;

            if (weapon.TryGet<WeaponTypeHandler>(out var handler))
            {
                if (handler.WeaponType == WeaponType.Melle)
                    _lootSpawnComponent.SpawnLoot(enemy);
            }
            
            if (_enemy.TryGet<EnemyRaggdolComponent>(out var component))
            {
                component.ActiveteRaggdol();
                return;
            }

            _enemy.Dispose();
        }
    }
}