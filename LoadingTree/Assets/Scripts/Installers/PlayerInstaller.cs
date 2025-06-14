using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Player>().AsSingle().NonLazy();
            Container.InstantiatePrefab(_playerPrefab);
            Debug.Log("Player installed");
        }
    }

    public class Player : IInitializable
    {
        public void PrintMassage()
        {
        }

        public void Initialize()
        {
            Debug.Log($"<color=yellow>{nameof(Player)}</color>");
        }
    }
}