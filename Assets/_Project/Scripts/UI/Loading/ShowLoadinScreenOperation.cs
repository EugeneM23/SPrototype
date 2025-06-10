namespace Gameplay
{
    public class ShowLoadinScreenOperation : ILoadingOperation
    {
        private readonly LoadingScreen _loadingScreen;

        public ShowLoadinScreenOperation(LoadingScreen loadingScreen)
        {
            _loadingScreen = loadingScreen;
        }

        public LoadingResult Load(LoadingBundle bundle)
        {
            _loadingScreen.Show();
 
            return LoadingResult.Success();
        }
    }
}