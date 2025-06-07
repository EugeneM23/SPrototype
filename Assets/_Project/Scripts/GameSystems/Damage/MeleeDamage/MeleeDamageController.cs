using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MeleeDamageController : IInitializable
    {
        private readonly MeleeDamageComponent _component;
        private readonly AnimationEventProvider _animationProvider;
        private readonly Entity _weapon;

        public MeleeDamageController(MeleeDamageComponent component, AnimationEventProvider animationProvider,
            Entity weapon)
        {
            _component = component;
            _animationProvider = animationProvider;
            _weapon = weapon;
        }

        public void Initialize()
        {
            _weapon.OnEntityEnable += OnEntityEnable;
            _weapon.OnEntityDisable += OnEntityDisable;
        }

        private void OnEntityDisable()
        {
            _animationProvider.OnEventCall -= _component.DamageCast;
        }

        private void OnEntityEnable()
        {
            _animationProvider.OnEventCall += _component.DamageCast;
        }
    }
}