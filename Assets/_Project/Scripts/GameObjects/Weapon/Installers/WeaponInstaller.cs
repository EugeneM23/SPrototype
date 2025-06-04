using System;
using Zenject;

namespace Gameplay
{
    public class WeaponInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WeaponInRangeCondition>().AsSingle().NonLazy();
            
            Container
                .Bind<WeaponShootComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<WeaponShootAnimationAction>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponCameraShakeAction>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<WeaponCooldownAction>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<WeaponFireController>()
                .AsSingle()
                .NonLazy();
        }
    }
}