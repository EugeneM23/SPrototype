using System.ComponentModel;
using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponMelleInstaller : MonoInstaller
    {
        [SerializeField] private DamageCastLayer _damageCastLayer;
        [SerializeField] private ParticleSystem _muzzleFlash;
        [SerializeField] private Transform _damageRoot;

        public override void InstallBindings()
        {
            Container.Bind<Transform>().WithId(ComponentsID.WeaponDamageRoot).FromInstance(_damageRoot).AsCached();


            Container
                .BindInterfacesAndSelfTo<WeaponCameraShaceComponent>()
                .AsSingle()
                .NonLazy();


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
                .BindInterfacesAndSelfTo<WeaponMelleAttackAction>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponSlashEffectHandler>()
                .AsSingle()
                .WithArguments(_muzzleFlash)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<DamageCastHandler>()
                .AsSingle()
                .WithArguments(_damageCastLayer)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponDamageCastController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponInRangeCondition>()
                .AsSingle()
                .NonLazy();
        }
    }
}