using Modules;
using Zenject;

namespace Gameplay
{
    public class PlayerMovementInstaller : Installer<PlayerMovementInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerMoveComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerRotationController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<RotationComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<LeanComponent>()
                .AsSingle()
                .NonLazy();


            Container
                .Bind<LookAtComponent>()
                .AsSingle()
                .NonLazy();
        }
    }
}