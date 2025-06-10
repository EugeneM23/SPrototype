using System.Collections.Generic;
using Zenject;

namespace Gameplay
{
    public class LoadingPipelineInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IReadOnlyList<ILoadingOperation>>().FromMethod(CreatePipeline).AsSingle();
        }

        private IReadOnlyList<ILoadingOperation> CreatePipeline(InjectContext injectContext)

        {
            DiContainer diContainer = injectContext.Container;

            return new ILoadingOperation[]
            {
                diContainer.Instantiate<ShowLoadinScreenOperation>(),

                diContainer.Instantiate<LoadSceneOperation>(),

                diContainer.Instantiate<HideLoadinScreenOperation>()
            };
        }
    }
}