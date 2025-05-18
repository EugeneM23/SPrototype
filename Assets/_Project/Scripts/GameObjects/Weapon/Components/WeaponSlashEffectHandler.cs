using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponSlashEffectHandler
    {
        private readonly ICharacterProvider _character;
        private readonly ParticleSystem _slashEffect;

        public WeaponSlashEffectHandler(ICharacterProvider character, ParticleSystem slashEffect)
        {
            _character = character;
            _slashEffect = slashEffect;

            if (_character.Character.TryGet<AnimationEventProvider>(out var eventProvider))
            {
                eventProvider.OnCall += PlaySlashEffect;
            }
        }

        private void PlaySlashEffect(string eventName)
        {
            if (eventName == "ASD")
            {
                Debug.Log("Slash effect played");
                var go = Object.Instantiate(_slashEffect);
                Transform root = _character.Character.Get<DiContainer>()
                    .ResolveId<Transform>(ComponentsID.MelleWeaponRoot);

                go.transform.position = root.position;
            }
        }
    }
}