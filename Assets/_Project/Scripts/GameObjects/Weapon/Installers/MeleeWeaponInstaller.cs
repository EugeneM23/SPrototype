using UnityEngine;

namespace Gameplay
{
    public class MeleeWeaponInstaller : BaseWeaponInstaller
    {
        [SerializeField] private MeleeWeaponConfig meleeConfig;

        public override void InstallBindings()
        {
            config = meleeConfig;
            Container.BindInterfacesAndSelfTo<MeleeWeaponConfig>().FromInstance(meleeConfig).AsSingle();
            base.InstallBindings();
        }

        protected override void SetupWeaponSpecific()
        {
            Container.BindInterfacesAndSelfTo<WeaponMelleAttackAction>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MeleeDamageComponent>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MeleeDamageController>().AsSingle().NonLazy();
        }
    }
}