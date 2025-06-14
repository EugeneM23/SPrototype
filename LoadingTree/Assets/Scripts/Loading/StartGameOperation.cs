using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Game
{
    public class StartGameOperation : IloadingOperation
    {
        public UniTask<LoadingResult> Load(LoadingBundle bundle)
        {
            SceneContext sceneContext = GameObject.FindObjectOfType<SceneContext>();
            DiContainer container = sceneContext.Container;
            container.Resolve<Player>().PrintMassage();
            
            return UniTask.FromResult(LoadingResult.SuccessOperation());
        }
    }
}