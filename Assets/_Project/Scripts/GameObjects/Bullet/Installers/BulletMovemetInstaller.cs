using Gameplay;
using Zenject;

public class BulletMovemetInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<BulletMoveComponent>()
            .AsSingle()
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<BulletMoveController>()
            .AsSingle()
            .NonLazy();
    }
}