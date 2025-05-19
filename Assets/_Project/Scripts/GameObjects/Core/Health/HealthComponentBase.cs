using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class HealthComponentBase : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private GameObject[] _deathEffectPrefab;
        public event Action<int> OnHealthChanged;
        public event Action<HealthComponentBase> OnDespawn;
        public event Action<Entity> OnDespawnTest;
        public event System.Action OnHit;
        public event Action<int> OnTakeDamaged;

        protected int _currentHealth;
        private bool _isDaied;

        private void OnEnable()
        {
            _isDaied = false;
            Reset();
        }

        protected virtual void Start()
        {
            _currentHealth = _maxHealth;
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            OnHealthChanged?.Invoke(_currentHealth);
            OnHit?.Invoke();
            OnTakeDamaged?.Invoke(damage);

            if (_currentHealth <= 0)
            {
                if (_deathEffectPrefab != null && !_isDaied)
                {
                    _isDaied = true;
                    int randomIndex = Random.Range(0, _deathEffectPrefab.Length);
                    Vector3 forward = transform.forward;
                    forward.y = 0;
                    var rotation = Quaternion.LookRotation(forward);

                    if (_deathEffectPrefab.Length > 0)
                    {
                        Instantiate(_deathEffectPrefab[randomIndex], transform.position + new Vector3(0, 3, 0),
                            rotation * Quaternion.Euler(0, 90, 0));
                    }
                }

                OnDespawn?.Invoke(this);
                OnDespawnTest?.Invoke(gameObject.GetComponentInParent<Entity>());
            }
        }

        public virtual void Reset()
        {
            _currentHealth = _maxHealth;
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
}