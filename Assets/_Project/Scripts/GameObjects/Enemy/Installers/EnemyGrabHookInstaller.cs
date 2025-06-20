using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyGrabHookInstaller", menuName = "Installers/AI/EnemyGrabHookInstaller")]
    public class EnemyGrabHookInstaller : ScriptableObjectInstaller<EnemyGrabHookInstaller>
    {
        [SerializeField] private float _initialTime = 1;
        [SerializeField] private float _rotationDuration = 1;
        [SerializeField] private int _rotationSpeed = 10;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyGrabHookDecision>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyGrabHookState>()
                .AsSingle()
                .WithArguments(_initialTime)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GrabHookRotationHandler>()
                .AsSingle()
                .WithArguments(_rotationSpeed, _rotationDuration)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GrabHookTranslateHandler>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<GrabHookMover>()
                .AsSingle()
                .NonLazy();
            Container
                .BindInterfacesAndSelfTo<GrabHookStateStatusHandler>()
                .AsSingle()
                .NonLazy();
            Container
                .BindInterfacesAndSelfTo<GrabHookCompletionHandler>()
                .AsSingle()
                .WithArguments(5f)
                .NonLazy();
        }
    }
}