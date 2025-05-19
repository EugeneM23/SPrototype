using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Pool
    {
    }

    public interface IEntitySpawner
    {
        Entity Spawn(string prefabName);
        void Despawn(string prefabName, Entity entity);
    }

    public interface IDisposableEntity
    {
        event Action<Entity> OnDispose;
    }

    public class GenericEntityPool : MonoMemoryPool<Entity>
    {
        protected override void OnSpawned(Entity entity)
        {
            entity.gameObject.SetActive(true);

            if (entity.TryGetComponent(out IDisposableEntity disposable))
            {
                disposable.OnDispose += Despawn;
            }
        }

        protected override void OnDespawned(Entity entity)
        {
            entity.gameObject.SetActive(false);

            if (entity.TryGetComponent(out IDisposableEntity disposable))
            {
                disposable.OnDispose -= Despawn;
            }
        }
    }

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

    public class EntityPoolInstaller : MonoInstaller
    {
        [SerializeField] private Entity[] entityPrefabs;

        public override void InstallBindings()
        {
            var pools = new Dictionary<string, IMemoryPool<Entity>>();

            foreach (var prefab in entityPrefabs)
            {
                string name = prefab.name;

                Container.BindMemoryPool<Entity, GenericEntityPool>()
                    .WithId(name)
                    .FromComponentInNewPrefab(prefab)
                    .UnderTransformGroup("PooledEntities");

                var pool = Container.ResolveId<IMemoryPool<Entity>>(name);
                pools[name] = pool;
            }

            Container.Bind<IEntitySpawner>().To<EntityPoolManager>().AsSingle().WithArguments(pools);
        }
    }

    public class EntitySpawnerExample : MonoBehaviour
    {
        [Inject] private IEntitySpawner _spawner;

        [SerializeField] private string prefabName;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var entity = _spawner.Spawn(prefabName);
                entity.transform.position = transform.position;
            }
        }
    }
}