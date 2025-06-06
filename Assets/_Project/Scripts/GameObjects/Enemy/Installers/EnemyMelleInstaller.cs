using UnityEngine;
using Zenject;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "EnemyMelleInstaller", menuName = "Installers/AI/EnemyMelleInstaller")]
    public class EnemyMelleInstaller : ScriptableObjectInstaller<EnemyMelleInstaller>
    {

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyMelleDecision>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyMeleeAttackState>()
                .AsSingle()
                .NonLazy();
        }
    }
}