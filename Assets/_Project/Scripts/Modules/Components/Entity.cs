using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public interface IEntity
    {
        T Get<T>();

        bool TryGet<T>(out T value);
    }

    public class Entity : MonoBehaviour, IEntity
    {
        public event Action<Entity> OnDispose;
        public event Action OnEntityDisable;
        public event Action OnEntityEnable;
        public event Action OnEntityStart;

        [SerializeField] private GameObjectContext _context;
        [SerializeField] private bool _isDisposableOverTime;
        [SerializeField] private float _destroyTime;

        private float _timer;
        [SerializeField] private bool _randomScale;

        private void Start()
        {
            /*if (_randomScale)
            {
                Debug.Log($"Random scale: {_randomScale}");
                float startscale = gameObject.transform.localScale.x;
                startscale /= 100 * 50;
                float rand = Random.Range(-startscale, startscale);
                gameObject.transform.localScale += new Vector3(rand, rand, rand);
                
            }*/

            OnEntityStart?.Invoke();
        }

        private void OnEnable()
        {
            _timer = _destroyTime;
            OnEntityEnable?.Invoke();
        }

        private void OnDisable() => OnEntityDisable?.Invoke();

        private void Update()
        {
            if (_isDisposableOverTime)
            {
                _timer -= Time.deltaTime;
                if (_timer <= 0)
                    Dispose();
            }
        }

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

            value = default;
            return false;
        }

        public void Dispose()
        {
            OnDispose?.Invoke(this);
        }

        public void TurnOnDisposeTime(float time)
        {
            _destroyTime = time;
            _isDisposableOverTime = true;
        }

        public void TurnOffDisposeOverTime()
        {
            _isDisposableOverTime = false;
        }
    }
}