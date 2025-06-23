using AudioEngine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class MeleeWeaponInstaller : BaseWeaponInstaller
    {
        [SerializeField] private MeleeWeaponConfig _meleeConfig;
        [SerializeField] private Transform _slashPoint;
        [SerializeField] private Entity _slash;

        [Header("SFX")] [SerializeField] private AudioEventKey _slashSound;

        public override void InstallBindings()
        {
            config = _meleeConfig;
            Container.BindInterfacesAndSelfTo<MeleeWeaponConfig>().FromInstance(_meleeConfig).AsSingle();
            base.InstallBindings();
        }

        protected override void SetupWeaponSpecific()
        {
            Container.BindInterfacesAndSelfTo<WeaponMelleAttackAction>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WeaponSlahController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WeaponMeleeSlahEffectAction>().AsSingle()
                .WithArguments(_slashPoint, _slash).NonLazy();

            Container.BindInterfacesAndSelfTo<MeleeDamageComponent>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<MeleeDamageController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<WeaponShootSFXAction>().AsSingle()
                .WithArguments(gameObject.transform, _slashSound)
                .NonLazy();
        }
    }
}