using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponMeleeSlahEffectAction
    {
        private readonly GameFactory _factory;
        private readonly Entity _slashEffect;
        private readonly Transform _slashPoint;

        public WeaponMeleeSlahEffectAction(GameFactory factory, Entity slashEffect, Transform slashPoint)
        {
            _factory = factory;
            _slashEffect = slashEffect;
            _slashPoint = slashPoint;
        }

        public void SpawnSlahEffect()
        {
            if (_slashEffect == null || _slashPoint == null) return;

            var slash = _factory.Create(_slashEffect);
            slash.transform.position = _slashPoint.position;
            slash.transform.rotation = _slashPoint.rotation;
        }

        public void SpawnSlahEffect(string aventName)
        {
            if (aventName == "Slash")
                SpawnSlahEffect();
        }
    }

    public class WeaponSlahController
    {
        private readonly WeaponMeleeSlahEffectAction _slashEffect;
        private readonly AnimationEventProvider _eventProvider;

        public WeaponSlahController(WeaponMeleeSlahEffectAction slashEffect, AnimationEventProvider eventProvider)
        {
            _slashEffect = slashEffect;
            _eventProvider = eventProvider;
        }

        public void TurnOff() => _eventProvider.OnEventCall -= _slashEffect.SpawnSlahEffect;

        public void TurnOn() => _eventProvider.OnEventCall += _slashEffect.SpawnSlahEffect;
    }
}