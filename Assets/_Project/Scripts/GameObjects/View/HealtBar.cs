using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class HealtBar : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [Inject] private readonly CharacterStats _stats;

        private int _currentHealth;

        private void Start()
        {
            _healthSlider.maxValue = _stats.MaxHealth;
            _currentHealth = _stats.MaxHealth;
            _healthSlider.value = _currentHealth;
        }

        public void UpdateHealthComponent(int health)
        {
            _healthSlider.value = health;
        }
    }
}