using DPrototype.Game;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "GameSysteInstaller", menuName = "Installers/GameSysteInstaller")]
    public class GameSysteInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public override void InstallBindings()
        {
            GameObject poolsParent = new GameObject("GamePools");

            Container.Bind<LoadingScreen>()
                .FromComponentInNewPrefab(_loadingScreen)
                .AsSingle()
                .OnInstantiated<LoadingScreen>((_, it) => it.Hide())
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<GameLauncher>().AsSingle().NonLazy();
            
            Container.Install<LoadingPipeLineInstaller>();

            Container
                .BindInstance(poolsParent.transform)
                .WithId("PoolsParent");

            Container
                .Bind<GameFactory>()
                .AsSingle()
                .NonLazy();

            // Глобальные системы
            Container
                .BindInterfacesAndSelfTo<GameInput>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<DelayedAction>()
                .AsSingle()
                .NonLazy();

            // Игровые системы
            Container
                .BindInterfacesAndSelfTo<PlayerCharacterProvider>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<DamageCasterManager>()
                .AsSingle()
                .NonLazy();

            /*Container
                .BindInterfacesAndSelfTo<CameraShaker>()
                .AsSingle()
                .WithArguments(Camera.main)
                .NonLazy();*/
        }
    }
}