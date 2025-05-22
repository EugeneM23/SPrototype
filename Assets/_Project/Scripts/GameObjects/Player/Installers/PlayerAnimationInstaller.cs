using Zenject;

namespace Gameplay
{
    public class PlayerAnimationInstaller : Installer<PlayerAnimationInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<CharacterConditions>()
                .AsSingle()
                .NonLazy();
            Container
                .BindInterfacesAndSelfTo<CharacterAnimationController>()
                .AsSingle()
                .NonLazy();
        }
    }
}