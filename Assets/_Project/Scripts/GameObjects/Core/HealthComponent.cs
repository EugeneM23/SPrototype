using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class HealthComponent : IInitializable, IDamageable
    {
        public event Action<int> OnHealthChanged;
        public event Action<int> OnTakeDamaged;

        public event Action<Entity> OnDead;

        private readonly Entity _entity;
        private readonly CharacterStats _stats;
        private int _currentHealth;

        public HealthComponent(CharacterStats stats, Entity entity)
        {
            _stats = stats;
            _entity = entity;
        }

        public void Initialize()
        {
            _currentHealth = _stats.MaxHealth;
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            OnHealthChanged?.Invoke(_currentHealth);
            OnTakeDamaged?.Invoke(damage);

            if (_currentHealth <= 0)
                HandleDeath();
        }

        private void HandleDeath()
        {
            OnDead?.Invoke(_entity);
            _currentHealth = _stats.MaxHealth;
            OnHealthChanged?.Invoke(_currentHealth);
        }

        public void Heal(int value)
        {
            _currentHealth = Mathf.Min(_currentHealth + value, _stats.MaxHealth);
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
}