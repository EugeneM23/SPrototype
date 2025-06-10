using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class LoadSceneOperation : ILoadingOperation
    {
        public LoadingResult Load(LoadingBundle bundle)
        {
            if (!bundle.TryGet(LoadinBundleKeys.L_Lobby, out int lobby))
            {
                return LoadingResult.Error("Failed to load lobby ");
            }

            int level = bundle.Get<int>(LoadinBundleKeys.L_Lobby);

            SceneManager.LoadScene(level, LoadSceneMode.Single);

            return LoadingResult.Success();
        }
    }
}