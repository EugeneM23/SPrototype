using Gameplay;
using UnityEngine;
using Zenject;

public class BulletInstaller : MonoInstaller
{
    [SerializeField] private ParticleSystem _impactEffect;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<Bullet>()
            .AsSingle()
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<BulletDamageEntiyCollisionAction>()
            .AsSingle()
            .NonLazy();
        Container
            .BindInterfacesAndSelfTo<BulletEnviromentHitAction>()
            .AsSingle()
            .WithArguments(_impactEffect)
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