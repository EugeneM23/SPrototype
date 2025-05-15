namespace Gameplay
{
    public interface IEnemyReasoner
    {
        int Priority { get; }
        bool CanReason();
        void ApplyReasoning();
    }
}