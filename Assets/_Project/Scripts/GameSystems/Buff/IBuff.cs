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
    }

    // Упрощенный BuffRage - содержит только уникальную логику

    // Пример использования:
// var rageBuff = new BuffBuilder<BuffRage>()
//     .Target(playerEntity)
//     .UI(rageUIEntity)
//     .Stackable(3)
//     .Timed(10f)
//     .Stats((BuffMultiplayerID.Speed, 2f), (BuffMultiplayerID.FireRate, 0.1f))
//     .Build();
//
// buffManager.AddBuff(rageBuff);
}