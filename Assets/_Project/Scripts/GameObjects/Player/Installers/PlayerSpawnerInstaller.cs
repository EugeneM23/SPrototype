using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;
        [Inject] private PlayerCharacterProvider _playerCharacterProvider;

        public override void InstallBindings()
        {
            var asd = Container.InstantiatePrefab(_playerPrefab);


            Container
                .Bind<Entity>()
                .WithId(CharacterParameterID.CharacterEntity)
                .FromInstance(asd.GetComponent<Entity>()).AsSingle().NonLazy();
        }
    }
}