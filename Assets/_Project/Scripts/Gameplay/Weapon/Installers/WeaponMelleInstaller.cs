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

            Container
                .BindInterfacesTo<WeaponMuzzleFlashComponent>()
                .AsSingle()
                .WithArguments(_muzzleFlash)
                .NonLazy();

            Container
                .Bind<WeaponShootComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponColldownComponent>()
                .AsSingle()
                .WithArguments(_setings);

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
        }
    }
}