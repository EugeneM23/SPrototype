using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameFactoryInstaller : MonoInstaller
    {
        [SerializeField] private Entity[] _prefabs;

        public override void InstallBindings()
        {
            GameObject poolsParent = new GameObject("GamePools");
            poolsParent.transform.SetParent(this.transform);

            for (int i = 0; i < _prefabs.Length; i++)
            {
                var prefab = _prefabs[i];

                GameObject poolContainer = new GameObject($"Pool_{prefab.name}");
                poolContainer.transform.SetParent(poolsParent.transform);

                Container.BindMemoryPool<Entity, EntityMemoryPool>()
                    .WithId(prefab.name)
                    .FromComponentInNewPrefab(prefab)
                    .UnderTransform(poolContainer.transform)
                    .NonLazy();
            }

            Container.BindInstance(_prefabs);
            Container.BindInstance(poolsParent.transform).WithId("PoolsParent");

            Container.Bind<GameFactory>().AsSingle().NonLazy();
        }
    }
}