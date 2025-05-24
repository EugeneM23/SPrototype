using Game;
using Modules;
using Zenject;

namespace Gameplay
{
    public class PlayerMovementInstaller : Installer<PlayerSetings, PlayerMovementInstaller>
    {
        [Inject] private PlayerCharacterProvider _player;
        [Inject] private PlayerSetings _playerSetings;

        public override void InstallBindings()
        {
            Container
                .Bind<PlayerMoveComponent>()
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
                .WithArguments(_player.Character.transform, _playerSetings.RotationSpeed)
                .NonLazy();

            Container
                .Bind<LeanComponent>()
                .AsSingle()
                .WithArguments(_player.Character.transform)
                .NonLazy();


            Container
                .Bind<LookAtComponent>()
                .AsSingle()
                .WithArguments(_player.Character.transform, _playerSetings.LookAtSpeed)
                .NonLazy();
        }
    }
}