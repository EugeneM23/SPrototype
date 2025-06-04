using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyMelleInstaller", menuName = "Installers/AI/EnemyMelleInstaller")]
    public class EnemyMelleInstaller : ScriptableObjectInstaller<EnemyMelleInstaller>
    {
        [SerializeField] private Entity _weapon;

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

            Container.Bind<Entity>().WithId(WeaponParameterID.MeleeWeapon).FromInstance(_weapon).AsCached().NonLazy();
        }
    }
}