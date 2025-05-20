using Modules;
using UnityEngine;
using Zenject;

namespace DPrototype.Game
{
    public class CameraInstaller : Installer<float, Camera, CameraInstaller>
    {
        [Inject] private float _smoothTime;
        [Inject] private Camera _camera;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<FollowComponent>()
                .AsSingle()
                .WithArguments(_camera.transform, _smoothTime)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<CameraShakeComponent>()
                .AsSingle()
                .WithArguments(_camera)
                .NonLazy();
        }
    }
}