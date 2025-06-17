using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyReloadInstaller", menuName = "Installers/AI/EnemyReloadInstaller")]
    public class EnemyReloadInstaller : ScriptableObjectInstaller<EnemyReloadInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyReloadDecision>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyReloadState>()
                .AsSingle()
                .NonLazy();
        }
    }
}