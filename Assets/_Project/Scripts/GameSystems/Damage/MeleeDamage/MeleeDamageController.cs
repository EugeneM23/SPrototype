using Zenject;

namespace Gameplay
{
    public class MeleeDamageController : IInitializable
    {
        private readonly MeleeDamageComponent _component;
        private readonly AnimationEventProvider _animationProvider;

        public MeleeDamageController(MeleeDamageComponent component, AnimationEventProvider animationProvider)
        {
            _component = component;
            _animationProvider = animationProvider;
        }

        public void Initialize()
        {
            _animationProvider.OnEventCall += _component.DamageCast;
        }
    }
}