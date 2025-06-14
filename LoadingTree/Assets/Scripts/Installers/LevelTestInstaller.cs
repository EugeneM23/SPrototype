using Zenject;

namespace Game
{
    public class LevelTestInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MassagePrinter>().AsSingle().NonLazy();
        }
    }
}