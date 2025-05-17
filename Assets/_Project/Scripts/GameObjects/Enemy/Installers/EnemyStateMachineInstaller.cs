using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyStateMachineInstaller", menuName = "Installers/AI/EnemyStateMachineInstaller")]
    public class EnemyStateMachineInstaller : ScriptableObjectInstaller<EnemyStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyStateMachine>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<DelayedAction>()
                .AsSingle()
                .NonLazy();
        }
    }
}