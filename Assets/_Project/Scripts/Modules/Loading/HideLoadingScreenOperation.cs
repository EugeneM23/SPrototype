using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public class HideLoadingScreenOperation : IloadingOperation
    {
        private LoadingScreen _loadingScreen;

        public HideLoadingScreenOperation(LoadingScreen loadingScreen)
        {
            _loadingScreen = loadingScreen;
        }

        public UniTask<LoadingResult> Load(LoadingBundle bundle)
        {
            _loadingScreen.Hide();
            
            return UniTask.FromResult(LoadingResult.SuccessOperation());
        }
    }
}