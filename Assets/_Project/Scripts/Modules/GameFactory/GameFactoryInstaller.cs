using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameObject poolsParent = new GameObject("GamePools");
            poolsParent.transform.SetParent(this.transform);

            Container
                .BindInstance(poolsParent.transform)
                .WithId("PoolsParent");

            Container
                .Bind<GameFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}