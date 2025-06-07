using System;

namespace Gameplay
{
    public interface IInventory
    {
        int BulletCount { get; set; }
        event Action OnBulletCountChanged;
        void AddBullets(int bullets);
    }
}