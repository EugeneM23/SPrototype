using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerSpawnInstaller : Installer<GameObject, PlayerSpawnInstaller>
    {
        [Inject] private GameObject _player;

        public override void InstallBindings()
        {
            Container
                .Bind<Entity>()
                .WithId(CharacterParameterID.CharacterEntity)
                .FromComponentInNewPrefab(_player).AsSingle().NonLazy();
           
            Container
                .BindInterfacesAndSelfTo<PlayerCharacterProvider>()
                .AsSingle()
                .NonLazy();
        }
    }
}