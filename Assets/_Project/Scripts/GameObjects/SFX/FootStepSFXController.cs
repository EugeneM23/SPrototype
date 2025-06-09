using Zenject;

namespace Gameplay
{
    public class FootStepSFXController : IInitializable
    {
        private readonly AnimationEventProvider _provider;
        private readonly StepSFXComponent _stepSfxComponent;

        public FootStepSFXController(AnimationEventProvider provider, StepSFXComponent stepSfxComponent)
        {
            _provider = provider;
            _stepSfxComponent = stepSfxComponent;
        }

        public void Initialize()
        {
            _provider.OnEventCall += _stepSfxComponent.FootStep;
        }
    }
}