using UnityEngine;
using Zenject;

namespace Gameplay
{
    public interface IEntity
    {
        T Get<T>();

        bool TryGet<T>(out T value);
    }

    public class Entity : MonoBehaviour, IEntity
    {
        [SerializeField] private GameObjectContext _context;

        public T Get<T>()
        {
            return _context.Container.Resolve<T>();
        }

        public bool TryGet<T>(out T value)
        {
            var resolved = _context.Container.TryResolve(typeof(T));
            if (resolved is T typedValue)
            {
                value = typedValue;
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }
    }
}