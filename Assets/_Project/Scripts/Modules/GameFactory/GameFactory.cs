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

        public GameFactory(
            DiContainer container,
            [Inject(Id = "PoolsParent", Optional = true)]
            Transform poolsParent
        )
        {
            _pools = new Dictionary<string, EntityMemoryPool>();
            _container = container;
            _poolsParent = poolsParent;
        }

        public Entity Create(Entity prefab, int initSize = 0)
        {
            string prefabName = prefab.name;

            if (!_pools.TryGetValue(prefabName, out EntityMemoryPool pool))
            {
                RegisterNewPrefab(prefab, initSize);
                pool = _pools[prefabName];
            }

            Entity entity = pool.Spawn();
            
            return entity;
        }

        private void RegisterNewPrefab(Entity prefab, int iniSize = 0)
        {
            string prefabName = prefab.name;

            GameObject poolContainer = new GameObject($"Pool_{prefabName}");
            poolContainer.transform.SetParent(_poolsParent);

            _container.BindMemoryPool<Entity, EntityMemoryPool>()
                .WithId(prefabName)
                .WithInitialSize(iniSize)
                .FromComponentInNewPrefab(prefab)
                .UnderTransform(poolContainer.transform)
                .NonLazy();

            EntityMemoryPool pool = _container.ResolveId<EntityMemoryPool>(prefabName);
            _pools[prefabName] = pool;
        }
    }
}