using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private Entity _playerPrefab;
        [SerializeField] private Entity _cameraHandler;

        [Inject] private readonly GameFactory _gameFactory;
        [Inject] private PlayerCharacterProvider _playerCharacterProvider;

        public override void InstallBindings()
        {
            var entity = _gameFactory.Create(_playerPrefab);
            entity.transform.position = gameObject.transform.position;

            _playerCharacterProvider.SetCharacter(entity);

            Container
                .Bind<Entity>()
                .WithId(CharacterParameterID.CharacterEntity)
                .FromInstance(entity.GetComponent<Entity>()).AsSingle().NonLazy();

            Container.InstantiatePrefab(_cameraHandler);
        }
    }
}