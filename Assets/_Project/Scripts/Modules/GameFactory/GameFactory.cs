using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameFactory
    {
        private readonly Dictionary<string, EntityMemoryPool> _pools;
        private readonly DiContainer _container;
        private readonly Transform _poolsParent;

        public GameFactory(DiContainer container, Entity[] lootPrefabs,
            [Inject(Id = "PoolsParent", Optional = true)]
            Transform poolsParent)
        {
            _pools = new Dictionary<string, EntityMemoryPool>();
            _container = container;
            _poolsParent = poolsParent;

            foreach (var prefab in lootPrefabs)
            {
                var pool = container.ResolveId<EntityMemoryPool>(prefab.name);
                _pools[prefab.name] = pool;
            }
        }

        public Entity Create(Entity prefab)
        {
            string prefabName = prefab.name;

            if (!_pools.TryGetValue(prefabName, out var pool))
            {
                RegisterNewPrefab(prefab);
                pool = _pools[prefabName];
            }

            Entity entity = pool.Spawn();
            return entity;
        }

        private void RegisterNewPrefab(Entity prefab)
        {
            string prefabName = prefab.name;

            GameObject poolContainer = new GameObject($"Pool_{prefabName}");
            poolContainer.transform.SetParent(_poolsParent);

            _container.BindMemoryPool<Entity, EntityMemoryPool>()
                .WithId(prefabName)
                .FromComponentInNewPrefab(prefab)
                .UnderTransform(poolContainer.transform)
                .NonLazy();

            var pool = _container.ResolveId<EntityMemoryPool>(prefabName);
            _pools[prefabName] = pool;
        }
    }
}