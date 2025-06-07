using UnityEngine;

namespace Gameplay
{
    public class MeleeWeaponInstaller : BaseWeaponInstaller
    {
        [SerializeField] private MeleeWeaponConfig meleeConfig;
        [SerializeField] private Transform _slashPoint;
        [SerializeField] private Entity _slash;

        public override void InstallBindings()
        {
            config = meleeConfig;
            Container.BindInterfacesAndSelfTo<MeleeWeaponConfig>().FromInstance(meleeConfig).AsSingle();
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
        }
    }
}