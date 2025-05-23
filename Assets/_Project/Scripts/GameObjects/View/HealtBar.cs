using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class HealtBar : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [Inject(Id = CharacterParameterID.Health)] private readonly int _maxHealth;

        private int _currentHealth;

        private void Start()
        {
            _healthSlider.maxValue = _maxHealth;
            _currentHealth = _maxHealth;
            _healthSlider.value = _currentHealth;
        }

        public void UpdateHealthComponent(int health)
        {
            _healthSlider.value = health;
        }
    }
}