using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyAirStrikeInstaller", menuName = "Installers/AI/EnemyAirStrikeInstaller")]
    public class EnemyAirStrikeInstaller : ScriptableObjectInstaller<EnemyStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyAirStrikeState>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyAirStikeDecision>()
                .AsSingle()
                .NonLazy();
        }
    }
}