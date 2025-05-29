using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class HitInstaller : MonoInstaller
    {
        [SerializeField] private Entity _hitEffect;
        [SerializeField] private Transform _hitRoot;

        public override void InstallBindings()
        {
            Container
                .Bind<HitComponent>()
                .AsSingle()
                .WithArguments(_hitEffect, _hitRoot)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<HitController>()
                .AsSingle()
                .NonLazy();
        }
    }
}