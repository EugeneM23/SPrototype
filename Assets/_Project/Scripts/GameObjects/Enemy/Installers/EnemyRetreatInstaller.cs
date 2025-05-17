using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyRetreatInstaller", menuName = "Installers/AI/EnemyRetreatInstaller")]

    public class EnemyRetreatInstaller : ScriptableObjectInstaller<EnemyRetreatInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyRetreatReasoner>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<EnemyRetreatState>()
                .AsSingle()
                .NonLazy();
        }
    }
}