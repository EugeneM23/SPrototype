using Zenject;

namespace Gameplay
{
    public class TakeDamageHealthController : IInitializable
    {
        private readonly HealthComponentBase _healthComponentBase;
        private HealtBar _healtBar;

        public TakeDamageHealthController(HealthComponentBase healthComponentBase, HealtBar healtBar)
        {
            _healthComponentBase = healthComponentBase;
            _healtBar = healtBar;
        }

        public void Initialize()
        {
            _healthComponentBase.OnHealthChanged += _healtBar.UpdateHealthComponentBase;
        }
    }
}