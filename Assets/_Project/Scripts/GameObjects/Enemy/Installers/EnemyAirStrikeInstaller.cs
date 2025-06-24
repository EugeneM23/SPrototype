using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyAirStrikeInstaller", menuName = "Installers/AI/EnemyAirStrikeInstaller")]
    public class EnemyAirStrikeInstaller : ScriptableObjectInstaller<EnemyStateMachineInstaller>
    {
        [SerializeField] private Entity _missilePrefab;
        [SerializeField] private LayerMask _missileLayerMask;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyAirStrikeState>()
                .AsSingle()
                .WithArguments(_missileLayerMask)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyAirStikeDecision>()
                .AsSingle()
                .NonLazy();
        }
    }
}