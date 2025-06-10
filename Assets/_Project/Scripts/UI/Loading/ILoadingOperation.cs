namespace Gameplay
{
    public interface ILoadingOperation
    {
        LoadingResult Load(LoadingBundle bundle);
    }

    public struct LoadingResult
    {
        public bool success;
        public string message;

        public static LoadingResult Success() => new() { success = true };
        public static LoadingResult Error(string error) => new() { success = false, message = error };
    }
}