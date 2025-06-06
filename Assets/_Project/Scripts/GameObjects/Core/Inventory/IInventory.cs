using System;

namespace Gameplay
{
    public interface IInventory
    {
        int BulletCount { get; set; }
        event Action OnBulletCountChanget;
    }
}