using UnityEngine;
using Zenject;

namespace Gameplay.Weapon
{
    public class EnemyWeaponInstaller : MonoInstaller
    {
        [Inject] private readonly Animator _animator;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyWeaponController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemySetFireRateToRangeState>()
                .AsSingle()
                .NonLazy();
        }
    }
}