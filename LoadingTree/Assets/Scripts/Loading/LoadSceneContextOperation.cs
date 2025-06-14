using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class LoadSceneContextOperation : IloadingOperation
    {
        public async UniTask<LoadingResult> Load(LoadingBundle bundle)
        {
            if (!bundle.TryGet(BundleKeys.BootLevel, out object result))
            {
                return LoadingResult.Error("Loading failed");
            }

            int scene = bundle.Get<int>(BundleKeys.BootLevel);

            await SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
            return LoadingResult.SuccessOperation();
        }
    }
}