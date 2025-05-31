namespace Gameplay
{
    public interface IBuff
    {
        void Apply();
        void Discard();
        void AddStack();
        void RefreshTimer();
        void Tick();
        bool IsTimed { get; }
        bool IsStackable { get; }
        bool IsExpired();
    }
}