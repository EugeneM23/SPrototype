using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyChaseInstaller", menuName = "Installers/AI/EnemyChaseInstaller")]
    public class EnemyChaseInstaller : ScriptableObjectInstaller<EnemyChaseInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyChaseDecision>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyChaseState>()
                .AsSingle()
                .NonLazy();
        }
    }
}