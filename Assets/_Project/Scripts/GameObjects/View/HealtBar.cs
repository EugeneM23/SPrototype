using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class HealtBar : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [Inject] private int _health;
        private int _currentHealth;

        private void Start()
        {
            _healthSlider.maxValue = _health;
            _currentHealth = _health;
            _healthSlider.value = _currentHealth;
        }

        public void UpdateHealthComponent(int health)
        {
            _healthSlider.value = health;
        }
    }
}