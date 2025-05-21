using System.ComponentModel;
using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private ParticleSystem _hitEffect;
        [SerializeField] private Transform _melleWeaponRoot;
        [SerializeField] private Transform _rangeweaponRoot;

        public override void InstallBindings()
        {
            EnemyMovementInstaller.Install(Container);

            Container.Bind<Transform>().WithId(ComponentsID.MelleWeaponRoot).FromInstance(_melleWeaponRoot).AsCached();
            Container.Bind<Transform>().WithId(ComponentsID.RangeWeaponRoot).FromInstance(_rangeweaponRoot).AsCached();

            Container.Bind<EnemyConditions>().AsSingle().NonLazy();
            Container
                .BindInterfacesAndSelfTo<EnemyAnimationBehaviour>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayEffectComponent>()
                .AsSingle()
                .WithArguments(_hitEffect).NonLazy();

            Container
                .BindInterfacesAndSelfTo<TakeDamageEffectSpawnController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyCharacterProvider>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<Enemy>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PushableObjectController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PushComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyAttackAssistComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<RandomPositionGenerator>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<TranslateComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyTargetManager>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<TargetComponent>()
                .AsSingle()
                .NonLazy();
        }
    }
}