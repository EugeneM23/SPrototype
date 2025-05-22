using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyJumpAttackInstaller", menuName = "Installers/AI/EnemyJumpAttackInstaller")]
    public class EnemyJumpAttackInstaller : ScriptableObjectInstaller<EnemyJumpAttackInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyJumpAttackDecision>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyJumpAttackState>()
                .AsSingle()
                .NonLazy();
        }
    }
}