using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private ParticleSystem _hitEffect;
        [SerializeField] private Transform _melleWeaponRoot;
        [SerializeField] private Transform _rangeweaponRoot;

        public override void InstallBindings()
        {
            Container.Bind<Transform>().WithId(ComponentsID.MelleWeaponRoot).FromInstance(_melleWeaponRoot).AsCached();
            Container.Bind<Transform>().WithId(ComponentsID.RangeWeaponRoot).FromInstance(_rangeweaponRoot).AsCached();

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
                .Bind<EnemyMoveComponent>()
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
        }
    }
}