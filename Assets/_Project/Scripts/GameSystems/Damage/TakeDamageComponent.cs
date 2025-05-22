using System;

namespace Gameplay
{
    public class TakeDamageComponent : IDamageable
    {
        private readonly Entity _entity;
        public event Action<int> OnHealthChanged;
        public event Action<int> OnTakeDamaged;
        public event Action<Entity> OnDespawn;

        private int _currentHealth = 100;

        public TakeDamageComponent(Entity entity)
        {
            _entity = entity;
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            OnHealthChanged?.Invoke(_currentHealth);
            OnTakeDamaged?.Invoke(damage);

            if (_currentHealth <= 0)
                OnDespawn?.Invoke(_entity);
        }
    }
}