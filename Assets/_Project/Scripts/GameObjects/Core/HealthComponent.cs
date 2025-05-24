using System;
using Zenject;

namespace Gameplay
{
    public class HealthComponent : IInitializable, IDamageable
    {
        private readonly Entity _entity;
        public event Action<int> OnHealthChanged;
        public event Action<int> OnTakeDamaged;
        public event Action<Entity> OnDespawn;

        [Inject(Id = CharacterParameterID.Health)]
        private int _maxhealth;

        private int _currentHealth;

        public void Initialize()
        {
            _currentHealth = _maxhealth;
        }

        public HealthComponent([Inject(Id = CharacterParameterID.CharacterEntity)] Entity entity)
        {
            _entity = entity;
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            OnHealthChanged?.Invoke(_currentHealth);
            OnTakeDamaged?.Invoke(damage);

            if (_currentHealth <= 0)
            {
                OnDespawn?.Invoke(_entity);
                _currentHealth = _maxhealth;
                OnHealthChanged?.Invoke(_currentHealth);
            }
        }
    }
}