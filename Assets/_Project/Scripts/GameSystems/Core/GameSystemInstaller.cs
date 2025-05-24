using DPrototype.Game;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameSystemInstaller : MonoInstaller
    {
        [SerializeField] private int _maximumFPS = 100;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _HUD;
        [SerializeField] private float _cameraSmoothTime;
        [SerializeField] private Camera _camera;

        public override void InstallBindings()
        {
            Application.targetFrameRate = _maximumFPS;

            UIInstaller.Install(Container, _HUD);
            CameraInstaller.Install(Container, _cameraSmoothTime, _camera);

            Container
                .BindInterfacesAndSelfTo<PlayerCharacterProvider>()
                .AsSingle()
                .NonLazy();
            Container
                .BindInterfacesAndSelfTo<DamageCasterManager>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GameInput>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<DelayedAction>()
                .AsSingle()
                .NonLazy();
        }
    }
}