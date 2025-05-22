using System;

namespace Gameplay
{
    public interface IShootable
    {
        event Action OnShoot;
    }
}