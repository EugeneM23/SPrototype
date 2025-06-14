using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class LoadSceneOperation : IloadingOperation
    {
        private AsyncOperation _operation;

        float GetProgress() => _operation.progress;
        float GetWeight() => 20f;

        public async UniTask<LoadingResult> Load(LoadingBundle bundle)
        {
            if (!bundle.TryGet(BundleKeys.Level, out object result))
                return LoadingResult.Error("Loading failed");

            int scene = bundle.Get<int>(BundleKeys.Level);

            _operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
            await _operation;

            return LoadingResult.SuccessOperation();
        }
    }
}