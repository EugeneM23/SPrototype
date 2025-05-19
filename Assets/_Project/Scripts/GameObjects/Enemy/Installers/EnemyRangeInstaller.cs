using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyRangeInstaller", menuName = "Installers/AI/EnemyRangeInstaller")]
    public class EnemyRangeInstaller : ScriptableObjectInstaller<EnemyRangeInstaller>
    {
        [SerializeField] private GameObject _weaponPrefab;

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

            Container
                .BindInterfacesAndSelfTo<RangeWeaponManager>()
                .AsSingle()
                .WithArguments(_weaponPrefab)
                .NonLazy();
        }
    }
}