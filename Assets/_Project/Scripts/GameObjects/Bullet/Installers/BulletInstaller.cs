using AudioEngine;
using Gameplay;
using UnityEngine;
using Zenject;

public class BulletInstaller : MonoInstaller
{
    [SerializeField] private Entity _effect;
    [SerializeField] private AudioEventKey _hitSFX;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<BulletDamageAction>()
            .AsSingle()
            .NonLazy();
        
        Container
            .BindInterfacesAndSelfTo<BulletEnviromentHitAction>()
            .AsSingle()
            .WithArguments(_effect)
            .NonLazy();
        
        Container
            .BindInterfacesAndSelfTo<BulletEnviromentHitSFXAction>()
            .AsSingle()
            .WithArguments(_hitSFX)
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<BulletHitCntroller>()
            .AsSingle()
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<BulletHitComponent>()
            .AsSingle()
            .NonLazy();
    }
}