using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyPatrolInstaller", menuName = "Installers/AI/EnemyPatrolInstaller")]
    public class EnemyPatrolInstaller : ScriptableObjectInstaller<EnemyPatrolInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyPatrolDecision>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyPatrolState>()
                .AsSingle()
                .NonLazy();
        }
    }
}