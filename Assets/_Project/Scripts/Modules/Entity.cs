using System;
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
        public event Action OnEntityDisable;
        public event Action OnEntityEnable;
        [SerializeField] private GameObjectContext _context;

        private void OnEnable() => OnEntityEnable?.Invoke();

        private void OnDisable() => OnEntityDisable?.Invoke();

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