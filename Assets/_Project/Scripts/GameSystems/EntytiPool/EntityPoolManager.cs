using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EntityPoolManager : IEntitySpawner
    {
        private readonly Dictionary<string, IMemoryPool<Entity>> _pools;

        public EntityPoolManager(Dictionary<string, IMemoryPool<Entity>> pools)
        {
            _pools = pools;
        }

        public Entity Spawn(string prefabName)
        {
            if (_pools.TryGetValue(prefabName, out var pool))
            {
                return pool.Spawn();
            }

            throw new Exception($"No pool found for prefab: {prefabName}");
        }

        public void Despawn(string prefabName, Entity entity)
        {
            if (_pools.TryGetValue(prefabName, out var pool))
            {
                pool.Despawn(entity);
            }
            else
            {
                Debug.LogWarning($"Trying to despawn unknown prefab: {prefabName}");
            }
        }
    }
}