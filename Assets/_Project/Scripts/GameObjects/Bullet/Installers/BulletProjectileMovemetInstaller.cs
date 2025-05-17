using Gameplay;
using Zenject;

public class BulletProjectileMovemetInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<BulletProjectileMoveComponent>()
            .AsSingle()
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<BulletMoveController>()
            .AsSingle()
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<PlayerSpeedObserver>()
            .AsSingle()
            .NonLazy();
    }
}