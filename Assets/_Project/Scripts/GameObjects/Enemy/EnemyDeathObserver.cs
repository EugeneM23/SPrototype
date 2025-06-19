using System;
using UnityEngine;

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
            _enemy.Get<HealthComponent>().OnDead += Death;
        }

        private void Death(Entity enemy)
        {
            var weapon = _player.Character.Get<PlayerWeaponManager>().CurrentWeapon;

            if (weapon.TryGet<WeaponTypeHandler>(out var handler))
            {
                if (handler.WeaponType == WeaponType.Melle)
                    _lootSpawnComponent.SpawnLoot(enemy);
            }

            if (_enemy.TryGet<EnemyDeathRaggdolComponent>(out var raggdolComponent))
            {
                raggdolComponent.ActiveteRaggdol();
                return;
            }

            if (_enemy.TryGet<DeathAnimationConmponent>(out var animationConmponent))
            {
                Debug.Log("death animation conmponent");
                animationConmponent.ActiveteAnimation();
                return;
            }


            _enemy.Dispose();
        }
    }
}