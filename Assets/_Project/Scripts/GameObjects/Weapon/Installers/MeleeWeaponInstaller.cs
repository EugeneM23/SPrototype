using UnityEngine;

namespace Gameplay
{
    public class MeleeWeaponInstaller : BaseWeaponInstaller
    {
        [SerializeField] private MeleeWeaponConfig meleeConfig;

        [Header("Melee Components")] [SerializeField]
        private Transform damageRoot;

        [SerializeField] private DamageCastLayer damageCastLayer;

        public override void InstallBindings()
        {
            config = meleeConfig;
            Container.BindInterfacesAndSelfTo<MeleeWeaponConfig>().FromInstance(meleeConfig).AsSingle();
            base.InstallBindings();
        }

        protected override void SetupWeaponSpecific()
        {
            Container.Bind<Transform>().WithId(DamageRootID.WeaponDamageRoot).FromInstance(damageRoot);
            Container.BindInterfacesAndSelfTo<WeaponMelleAttackAction>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WeaponDamageCastAction>().AsSingle().WithArguments(damageCastLayer)
                .NonLazy();
        }
    }
}