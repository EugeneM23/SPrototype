using System;

namespace Gameplay
{
    public interface IEnemyDecision
    {
        int Priority { get; }
        bool IsValid();
        Type GetState();
    }
}