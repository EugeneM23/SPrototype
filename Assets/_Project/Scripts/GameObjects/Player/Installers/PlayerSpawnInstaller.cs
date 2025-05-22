using Zenject;

namespace Gameplay
{
    public class PlayerSpawnInstaller : Installer<Entity, PlayerSpawnInstaller>
    {
        [Inject] private Entity _player;

        public override void InstallBindings()
        {
            Container
                .Bind<Entity>()
                .FromComponentInNewPrefab(_player).AsSingle().NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerCharacterProvider>()
                .AsSingle()
                .NonLazy();
        }
    }
}