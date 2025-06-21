using AudioEngine;
using Gameplay;
using UnityEngine;
using Zenject;

public class BulletInstaller : MonoInstaller
{
    [SerializeField] private Entity _effect;
    [SerializeField] private AudioEventKey _hitSFX;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private bool _castEffectToEntity;
    [SerializeField] private bool _isSplashDamageBullet;

    public override void InstallBindings()
    {
        if (_castEffectToEntity)
        {
            Container
                .BindInterfacesAndSelfTo<BulletEntityHitAction>()
                .AsSingle()
                .WithArguments(_effect)
                .NonLazy();
        }

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

        if (_isSplashDamageBullet)
        {
            Container.Bind<IBulletHIt>().To<BulletSplashHitComponent>().AsSingle().NonLazy();
        }
        else
        {
            Container.Bind<IBulletHIt>().To<BulletHitComponent>().AsSingle().NonLazy();
        }

        Container
            .BindInterfacesAndSelfTo<BulletCollisionComponent>()
            .AsSingle()
            .NonLazy();
    }
}