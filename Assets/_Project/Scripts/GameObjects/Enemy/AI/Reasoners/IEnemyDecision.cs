namespace Gameplay
{
    public interface IEnemyDecision
    {
        int Priority { get; }
        bool IsValid();
        void ApplyReasoning();
    }
}