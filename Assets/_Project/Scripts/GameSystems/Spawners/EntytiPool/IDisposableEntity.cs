using System;

namespace Gameplay
{
    public interface IDisposableEntity
    {
        event Action<Entity> OnDispose;
    }
}