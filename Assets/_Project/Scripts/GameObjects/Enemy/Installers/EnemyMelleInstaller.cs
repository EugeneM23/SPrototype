using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyMelleInstaller", menuName = "Installers/AI/EnemyMelleInstaller")]
    public class EnemyMelleInstaller : ScriptableObjectInstaller<EnemyMelleInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyMelleReasoner>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyMeleeAttackState>()
                .AsSingle()
                .NonLazy();
        }
    }
}