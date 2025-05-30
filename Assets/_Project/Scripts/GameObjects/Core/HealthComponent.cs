using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Gameplay
{
    public class HealthComponent : IInitializable, IDamageable
    {
        public event Action<int> OnHealthChanged;
        public event Action<int> OnTakeDamaged;

        private readonly Entity _entity;

        private int _maxhealth;
        private int _currentHealth;

        public void Initialize()
        {
            _currentHealth = _maxhealth;
        }

        public HealthComponent(
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity entity,
            [Inject(Id = CharacterParameterID.Health)]
            int maxhealth
        )
        {
            _entity = entity;
            _maxhealth = maxhealth;
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            OnHealthChanged?.Invoke(_currentHealth);
            OnTakeDamaged?.Invoke(damage);

            if (_currentHealth <= 0)
            {
                _entity.Dispose();
                _currentHealth = _maxhealth;
                OnHealthChanged?.Invoke(_currentHealth);
            }
        }

        public void Heal(int value)
        {
            if (_currentHealth + value <= _maxhealth)
                _currentHealth += value;
            else
                _currentHealth = _maxhealth;

            OnHealthChanged?.Invoke(_currentHealth);
        }
    }

    public class CharacterStats
    {
        [Inject(Id = CharacterParameterID.Health)]
        private int _CurrentHealth;

        [Inject(Id = CharacterParameterID.MoveSpeed, Optional = true)]
        private int _movespeed;

        [Inject(Id = CharacterParameterID.MoveSpeed, Optional = true)]
        private float _attackrate;
    }
}