using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyDeathObserver : ITickable
    {
        private readonly Entity _enemy;
        private readonly LootSpawnComponent _lootSpawnComponent;
        private readonly PlayerCharacterProvider _player;
        private bool _isDead;
        private float _timer;

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

            _enemy.Get<CharacterConditions>().IsAlive = false;
            _enemy.Get<NavMeshAgent>().enabled = false;
            _enemy.Get<Animator>().enabled = false;
            _enemy.Get<HealtBar>().gameObject.SetActive(false);
            _enemy.Get<CapsuleCollider>().enabled = false;
            _enemy.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            _enemy.Get<Rigidbody>().isKinematic = false;
            _timer = 2f;
            _isDead = true;
            var go = _enemy.GetComponentsInChildren<Rigidbody>();
            foreach (var item in go)
            {
                item.linearVelocity = Vector3.zero;
                item.angularVelocity = Vector3.zero;

                item.AddForce(-_enemy.gameObject.transform.forward * 50, ForceMode.Impulse);
                item.AddTorque(-_enemy.gameObject.transform.forward + Vector3.up * 50, ForceMode.Impulse);
            }
        }

        public void Tick()
        {
            if (_isDead)
            {
                Debug.Log("Dispose");

                _timer -= Time.deltaTime;
                if (_timer <= 0)
                {
                    _enemy.Get<CharacterConditions>().IsAlive = true;
                    _enemy.Get<NavMeshAgent>().enabled = true;
                    _enemy.Get<Animator>().enabled = true;
                    _enemy.Get<HealtBar>().gameObject.SetActive(true);
                    _enemy.Get<GameKarnel>().enabled = true;
                    _enemy.Get<CapsuleCollider>().enabled = true;
                    _enemy.gameObject.layer = LayerMask.NameToLayer("Enemy");
                    _enemy.Get<Rigidbody>().isKinematic = true;
                    _enemy.Dispose();
                    _isDead = false;
                }
            }
        }
    }
}