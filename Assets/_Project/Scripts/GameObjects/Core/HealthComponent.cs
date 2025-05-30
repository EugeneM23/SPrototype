using System;
using Zenject;

namespace Gameplay
{
    public class HealthComponent : IInitializable, IDamageable
    {
        public event Action<int> OnHealthChanged;
        public event Action<int> OnTakeDamaged;

        private readonly Entity _entity;

        private readonly CharacterStats _stats;
        private int _currentHealth;

        public void Initialize() => _currentHealth = _stats.MaxHealth;

        public HealthComponent(CharacterStats stats, Entity entity)
        {
            _stats = stats;
            _entity = entity;
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            OnHealthChanged?.Invoke(_currentHealth);
            OnTakeDamaged?.Invoke(damage);

            if (_currentHealth <= 0)
            {
                _entity.Dispose();
                _currentHealth = _stats.MaxHealth;
                OnHealthChanged?.Invoke(_currentHealth);
            }
        }

        public void Heal(int value)
        {
            if (_currentHealth + value <= _stats.MaxHealth)
                _currentHealth += value;
            else
                _currentHealth = _stats.MaxHealth;

            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
}