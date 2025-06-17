using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyRangeInstaller", menuName = "Installers/AI/EnemyRangeInstaller")]
    public class EnemyRangeInstaller : ScriptableObjectInstaller<EnemyRangeInstaller>
    {
        [SerializeField] private int _range;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyRangeDecision>()
                .AsSingle()
                .WithArguments(_range)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyRangeAttackState>()
                .AsSingle()
                .NonLazy();
        }
    }
}