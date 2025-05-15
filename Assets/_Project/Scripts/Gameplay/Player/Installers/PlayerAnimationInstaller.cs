using Zenject;

namespace Gameplay
{
    public class PlayerAnimationInstaller : Installer<PlayerAnimationInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerAnimationBehaviour>()
                .AsSingle()
                .NonLazy();
        }
    }
}