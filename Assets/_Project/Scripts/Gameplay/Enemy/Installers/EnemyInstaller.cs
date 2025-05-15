using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private ParticleSystem _hitEffect;

        public override void InstallBindings()
        {
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

            /*Container
                .Bind<WeaponManager>()
                .AsSingle()
                .WithArguments(Container, _weaponPrefab)
                .NonLazy();*/


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