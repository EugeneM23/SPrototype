using UnityEngine;
using Zenject;

namespace Gameplay
{
    [CreateAssetMenu(
        fileName = "LoadingScreen",
        menuName = "UI/LoadingScreen")
    ]
    public class LoadingScreenInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public override void InstallBindings()
        {
            Container.Bind<LoadingScreen>().FromComponentInNewPrefab(_loadingScreen).AsSingle()
                .OnInstantiated<LoadingScreen>(((_, it) => it.Hide())).NonLazy(); 

            Container.Install<LoadingPipelineInstaller>();
        }
    }
}