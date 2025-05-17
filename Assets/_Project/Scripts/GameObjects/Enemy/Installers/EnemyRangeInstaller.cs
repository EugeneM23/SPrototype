using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyRangeInstaller", menuName = "Installers/AI/EnemyRangeInstaller")]

    public class EnemyRangeInstaller : ScriptableObjectInstaller<EnemyRangeInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyRangeReasoner>()
                .AsSingle()
                .NonLazy();


            Container
                .BindInterfacesAndSelfTo<EnemyRangeAttackState>()
                .AsSingle()
                .NonLazy();
        }
    }
}