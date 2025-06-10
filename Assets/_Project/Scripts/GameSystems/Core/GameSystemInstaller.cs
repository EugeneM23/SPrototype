using AudioEngine;
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
        [SerializeField] private AudioEventKey _hitSfx;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameLauncher>()
                .AsSingle()
                .NonLazy();

            Application.targetFrameRate = _maximumFPS;

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

            Container
                .BindInterfacesAndSelfTo<AnabienGameSound>()
                .AsSingle()
                .WithArguments(_hitSfx)
                .NonLazy();

            Container.InstantiatePrefab(_HUD);
        }
    }

    public class AnabienGameSound : IInitializable
    {
        private readonly AudioEventKey _hitSfx;

        private AudioSystem _audioSystem;

        public AnabienGameSound(AudioEventKey hitSfx)
        {
            _hitSfx = hitSfx;
        }

        public void Initialize()
        {
            _audioSystem = AudioSystem.Instance;
            _audioSystem.PlayEvent(_hitSfx);
        }
    }
}