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
            Entity entity = Container.InstantiatePrefab(_playerPrefab).GetComponent<Entity>();
            _playerCharacterProvider.SetCharacter(entity);

            Container
                .Bind<Entity>()
                .WithId(CharacterParameterID.CharacterEntity)
                .FromInstance(entity.GetComponent<Entity>()).AsSingle().NonLazy();
        }
    }
}