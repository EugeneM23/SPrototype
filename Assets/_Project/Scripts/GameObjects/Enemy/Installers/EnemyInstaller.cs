using System.ComponentModel;
using Gameplay.Installers;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private Transform _melleWeaponRoot;
        [SerializeField] private Transform _rangeWeaponRoot;
        [SerializeField] private Entity _entity;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyCharacterProvider>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<Entity>()
                .WithId(CharacterParameterID.CharacterEntity)
                .FromInstance(gameObject.GetComponent<Entity>())
                .AsSingle()
                .NonLazy();

            Container.Bind<Transform>().WithId(DamageRootID.MelleWeaponRoot).FromInstance(_melleWeaponRoot).AsCached();
            Container.Bind<Transform>().WithId(DamageRootID.RangeWeaponRoot).FromInstance(_rangeWeaponRoot).AsCached();

            Container.Bind<CharacterConditions>().AsSingle().NonLazy();
            Container
                .BindInterfacesAndSelfTo<CharacterAnimationController>()
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
            Container
                .Bind<CharacterStats>()
                .AsSingle()
                .NonLazy();
            Container.BindInterfacesAndSelfTo<BuffManager>().AsSingle().NonLazy();

            EnemyMovementInstaller.Install(Container);
            
        }
    }
}