using Gameplay;
using UnityEngine;
using Zenject;

public class BulletInstaller : MonoInstaller
{
    [SerializeField] private ParticleSystem _impactEffect;
    [SerializeField] private CollisionComponent _collisionComponent;
    [SerializeField] private Entity _entity;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<BulletCollisionController>()
            .AsSingle()
            .WithArguments(_collisionComponent)
            .NonLazy();

        Container
            .Bind<Bullet>()
            .AsSingle()
            .WithArguments(_entity)
            .NonLazy();

        /*Container
            .BindInterfacesAndSelfTo<BulletPushComponent>()
            .AsSingle()
            .WithArguments(gameObject.GetComponent<Entity>())
            .NonLazy();*/

        Container
            .BindInterfacesAndSelfTo<BulletDamageComponent>()
            .AsSingle()
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<EnviromentHitEffectComponent>()
            .AsSingle()
            .WithArguments(_impactEffect)
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<BulletMoveComponent>()
            .AsSingle()
            .WithArguments(this.transform)
            .NonLazy();
    }
}