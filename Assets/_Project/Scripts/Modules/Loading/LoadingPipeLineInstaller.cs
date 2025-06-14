using System;
using System.Collections.Generic;
using Zenject;

namespace Gameplay
{
    public class LoadingPipeLineInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IReadOnlyList<IloadingOperation>>().FromMethod(CreatePipeline).AsSingle();
        }

        private IReadOnlyList<IloadingOperation> CreatePipeline(InjectContext injectContext)
        {
            DiContainer container = injectContext.Container;
            return new IloadingOperation[]
            {
                container.Instantiate<LoadSceneOperation>(),
                container.Instantiate<LoadSceneContextOperation>(),
                container.Instantiate<StartGameOperation>(),
            };
        }
    }
}