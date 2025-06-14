using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class StartGameOperation : IloadingOperation
    {
        public UniTask<LoadingResult> Load(LoadingBundle bundle)
        {
            SceneContext sceneContext = GameObject.FindObjectOfType<SceneContext>();
            DiContainer container = sceneContext.Container;
            
            return UniTask.FromResult(LoadingResult.SuccessOperation());
        }
    }
}