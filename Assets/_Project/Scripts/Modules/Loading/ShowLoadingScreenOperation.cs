using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class ShowLoadingScreenOperation : IloadingOperation
    {
        private LoadingScreen _loadingScreen;

        public ShowLoadingScreenOperation(LoadingScreen loadingScreen)
        {
            _loadingScreen = loadingScreen;
        }

        public UniTask<LoadingResult> Load(LoadingBundle bundle)
        {
            _loadingScreen.Show();

            return UniTask.FromResult(LoadingResult.SuccessOperation());
        }
    }
}