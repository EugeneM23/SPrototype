namespace Gameplay
{
    public interface ILoadingOperation
    {
        UniTask<LoadingResult> Load(LoadingBundle bundle);
    }
}