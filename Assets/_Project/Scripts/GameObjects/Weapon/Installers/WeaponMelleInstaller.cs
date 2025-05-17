using System.ComponentModel;
using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponMelleInstaller : MonoInstaller
    {
        [SerializeField] private WeaponSetings _setings;
        [SerializeField] private ParticleSystem _muzzleFlash;
        [SerializeField] private Entity _weponModel;
        [SerializeField] private Transform _weaponBone;

        public override void InstallBindings()
        {
            Container
                .Bind<WeaponSetings>()
                .FromInstance(_setings)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponCameraShaceComponent>()
                .AsSingle()
                .NonLazy();

            /*Container
                .BindInterfacesTo<WeaponMuzzleFlashComponent>()
                .AsSingle()
                .WithArguments(_muzzleFlash)
                .NonLazy();*/

            Container
                .Bind<WeaponShootComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponFireController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponTargetController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<WeaponTargetComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponMelleAttack>()
                .AsSingle()
                .NonLazy();


            Container
                .BindInterfacesAndSelfTo<TestComponent>()
                .AsSingle()
                .WithArguments(_muzzleFlash)
                .NonLazy();
        }
    }

    public class TestComponent
    {
        private readonly ICharacterProvider _character;
        private readonly ParticleSystem _slashEffect;

        public TestComponent(ICharacterProvider character, ParticleSystem slashEffect)
        {
            _character = character;
            _slashEffect = slashEffect;

            if (_character.Character.TryGet<AnimationEventProvider>(out var eventProvider))
            {
                eventProvider.OnCall += PlaySlawEffect;
            }
        }

        private void PlaySlawEffect(string eventName)
        {
            if (eventName == "SlashEffect")
            {
                var go = Object.Instantiate(_slashEffect);
                Transform root = _character.Character.Get<DiContainer>()
                    .ResolveId<Transform>(ComponentsID.MelleWeaponRoot);

                go.transform.position = root.position;
            }
        }
    }
}