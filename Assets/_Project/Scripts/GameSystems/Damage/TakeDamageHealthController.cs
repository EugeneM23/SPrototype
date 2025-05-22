using Zenject;

namespace Gameplay
{
    public class TakeDamageHealthController : IInitializable
    {
        private readonly TakeDamageComponent _takeDamageComponent;
        private HealtBar _healtBar;

        public TakeDamageHealthController(
            HealtBar healtBar,
            TakeDamageComponent takeDamageComponent
        )
        {
            _healtBar = healtBar;
            _takeDamageComponent = takeDamageComponent;
        }

        public void Initialize()
        {
            _takeDamageComponent.OnHealthChanged += _healtBar.UpdateHealthComponent;
        }
    }
}