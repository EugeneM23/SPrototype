using System;
using System.Collections.ObjectModel;

namespace Gameplay
{
    public class HideLoadinScreenOperation : ILoadingOperation
    {
        private readonly LoadingScreen _loadingScreen;

        public HideLoadinScreenOperation(LoadingScreen loadingScreen) => _loadingScreen = loadingScreen;

        public LoadingResult Load(LoadingBundle bundle)
        {
            _loadingScreen.Hide();
            return LoadingResult.Success();
        }
    }
}