using Zenject;

namespace Gameplay
{
    public class TakeDamageHealthController : IInitializable
    {
        private readonly HealthComponent _healthComponent;
        private HealtBar _healtBar;

        public TakeDamageHealthController(
            HealtBar healtBar,
            HealthComponent healthComponent
        )
        {
            _healtBar = healtBar;
            _healthComponent = healthComponent;
        }

        public void Initialize()
        {
            _healthComponent.OnHealthChanged += _healtBar.UpdateHealthComponent;
        }
    }
}