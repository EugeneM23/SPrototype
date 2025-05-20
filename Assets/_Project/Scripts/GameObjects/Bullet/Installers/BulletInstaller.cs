using Gameplay;
using UnityEngine;
using Zenject;

public class BulletInstaller : MonoInstaller
{
    [SerializeField] private ParticleSystem _impactEffect;
    [SerializeField] private CollisionComponent _collisionComponent;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<Bullet>()
            .AsSingle()
            .WithArguments(_collisionComponent)
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
        
    }
}