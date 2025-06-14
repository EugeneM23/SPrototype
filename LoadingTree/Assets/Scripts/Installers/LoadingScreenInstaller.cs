using TMPro;
using UnityEngine;
using Zenject;

namespace Game
{
    [CreateAssetMenu(fileName = "LoadingScreenInstaller", menuName = "Installers/LoadingScreenInstaller")]
    public class LoadingScreenInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreenPrefab;

        public override void InstallBindings()
        {
            Container.Bind<LoadingScreen>()
                .FromComponentInNewPrefab(_loadingScreenPrefab)
                .AsSingle()
                .OnInstantiated<LoadingScreen>((_, it) => it.Hide())
                .NonLazy();
        }
    }
}