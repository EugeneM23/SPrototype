using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyMelleInstaller", menuName = "Installers/AI/EnemyMelleInstaller")]
    public class EnemyMelleInstaller : ScriptableObjectInstaller<EnemyMelleInstaller>
    {
        [SerializeField] private GameObject _weaponPrefab;

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

            Container
                .BindInterfacesAndSelfTo<MelleWeaponManager>()
                .AsSingle()
                .WithArguments(_weaponPrefab)
                .NonLazy();
        }
    }
}