using Gameplay;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyPool : MemoryPool<Vector3, Entity>
    {
        public Entity Create(Vector3 position) => Spawn(position);

        protected override void Reinitialize(Vector3 position, Entity enemy)
        {
            enemy.gameObject.transform.position = position;
        }

        protected override void OnSpawned(Entity enemy)
        {
            base.OnSpawned(enemy);
            enemy.Get<HealthComponentBase>().OnDespawnTest += Despawn;
            enemy.gameObject.SetActive(true);
        }

        protected override void OnDespawned(Entity enemy)
        {
            base.OnDespawned(enemy);
            enemy.Get<HealthComponentBase>().OnDespawnTest -= Despawn;
            enemy.gameObject.SetActive(false);
        }
    }
}