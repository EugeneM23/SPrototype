using System.ComponentModel;
using Gameplay.Installers;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private ParticleSystem _hitEffect;
        [SerializeField] private Transform _melleWeaponRoot;
        [SerializeField] private Transform _rangeweaponRoot;
        [SerializeField] private Entity _entity;

        public override void InstallBindings()
        {
            EnemyMovementInstaller.Install(Container);
            Container
                .Bind<Entity>()
                .WithId(CharacterParameterID.CharacterEntity)
                .FromInstance(_entity).AsSingle().NonLazy();

            Container.Bind<Transform>().WithId(DamageRootID.MelleWeaponRoot).FromInstance(_melleWeaponRoot).AsCached();
            Container.Bind<Transform>().WithId(DamageRootID.RangeWeaponRoot).FromInstance(_rangeweaponRoot).AsCached();

            Container.Bind<CharacterConditions>().AsSingle().NonLazy();
            Container
                .BindInterfacesAndSelfTo<CharacterAnimationController>()
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