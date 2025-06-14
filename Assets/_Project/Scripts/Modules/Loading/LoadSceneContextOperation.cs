using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class LoadSceneContextOperation : IloadingOperation
    {
        float GetWeight() => 20f;

        public async UniTask<LoadingResult> Load(LoadingBundle bundle)
        {
            if (!bundle.TryGet(BundleKeys.BootLevel, out object result))
            {
                return LoadingResult.Error("Loading failed");
            }

            int scene = bundle.Get<int>(BundleKeys.BootLevel);

            await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
            await SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

            return LoadingResult.SuccessOperation();
        }
    }
}