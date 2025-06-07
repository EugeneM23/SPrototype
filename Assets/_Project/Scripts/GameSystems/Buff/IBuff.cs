using System;

namespace Gameplay
{
    // Интерфейс для баффов
    public interface IBuff
    {
        bool IsStackable { get; }
        bool IsTimed { get; }
        void Configure(BuffConfig config);
        void Apply();
        void Tick();
        void Discard();
        bool IsExpired();
        void AddStack();
        void RefreshTimer();
        event Action<int> OnStack;
        event Action OnApply;
        event Action<float> OnTick;
        event Action OnDiscard;
    }
}