using Modules;
using Zenject;

namespace Gameplay
{
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerCameraController>().AsSingle().NonLazy();

            Container
                .BindInterfacesAndSelfTo<FollowComponent>()
                .AsSingle()
                .WithArguments(this.gameObject.transform, 0.2f)
                .NonLazy();
        }
    }
}