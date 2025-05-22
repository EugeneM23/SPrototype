using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
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
}