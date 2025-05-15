using Game;
using Modules;
using Zenject;

namespace Gameplay
{
    public class PlayerMovementInstaller : Installer<PlayerSetings, PlayerMovementInstaller>
    {
        [Inject] private Entity _player;
        [Inject] private PlayerSetings _playerSetings;

        public override void InstallBindings()
        {
            Container
                .Bind<CharacterMoveComponent>()
                .AsSingle()
                .WithArguments(_playerSetings.RunSpeed)
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
                .WithArguments(_player.transform, _playerSetings.RotationSpeed)
                .NonLazy();

            Container
                .Bind<LeanComponent>()
                .AsSingle()
                .WithArguments(_player.transform)
                .NonLazy();


            Container
                .Bind<LookAtComponent>()
                .AsSingle()
                .WithArguments(_player.transform, _playerSetings.LookAtSpeed)
                .NonLazy();
        }
    }
}