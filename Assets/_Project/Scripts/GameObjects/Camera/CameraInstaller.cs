using Modules;
using UnityEngine;
using Zenject;

namespace DPrototype.Game
{
    public class CameraInstaller : Installer<float, CameraInstaller>
    {
        [Inject] private float _smoothTime; 
       // [Inject] private Camera _camera;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<FollowComponent>()
                .AsSingle()
                .WithArguments(Camera.main.transform, _smoothTime)
                .NonLazy();

            /*Container
                .BindInterfacesAndSelfTo<CameraShaker>()
                .AsSingle()
                .WithArguments(Camera.main)
                .NonLazy();*/
        }
    }
}