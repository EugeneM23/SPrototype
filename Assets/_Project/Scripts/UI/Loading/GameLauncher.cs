using System.Collections.Generic;
using Zenject;

namespace Gameplay
{
    public class GameLauncher : IInitializable
    {
        private readonly IReadOnlyList<ILoadingOperation> _loadingOperations;
        private readonly LoadingScreen _loadingScreen;

        public GameLauncher(IReadOnlyList<ILoadingOperation> loadingOperations, LoadingScreen loadingScreen)
        {
            _loadingOperations = loadingOperations;
            _loadingScreen = loadingScreen;
        }

        public async void Lounch(int level = 1)
        {
            LoadingBundle loadingBundle = new LoadingBundle();
            loadingBundle.Add(LoadinBundleKeys.L_Lobby, level);

            foreach (var item in _loadingOperations)
            {
                LoadingResult result = item.Load(loadingBundle);

                if (!result.success)
                {
                    _loadingScreen.SetError(result.message);
                    break;
                }
            }
        }

        public void Initialize() => Lounch();
    }
}