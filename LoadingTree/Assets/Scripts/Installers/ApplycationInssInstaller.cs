using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game
{
    [CreateAssetMenu(fileName = "ApplycationInssInstaller", menuName = "Installers/ApplycationInssInstaller")]
    public class ApplycationInssInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameLauncher>().AsSingle().NonLazy();

            Container.Install<LoadingPipeLineInstaller>();
        }
    }
}