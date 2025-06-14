using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public interface IloadingOperation
    {
        public UniTask<LoadingResult> Load(LoadingBundle bundle);
 
        float GetProgress() => 1;
        float GetWeight() => 1;
    }
}