using DamageNumbersPro;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class EnemyHealthInstaller : MonoInstaller
    {
        [SerializeField] private DamageNumber _damageNumbers;
        [SerializeField] private HealtBar _healtBar;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<HealthComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<TakeDamageNumberSpawController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<DamageNumberSpawner>()
                .AsSingle()
                .WithArguments(_damageNumbers)
                .NonLazy();

            Container
                .Bind<EnemyDeathObserver>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<TakeDamageHealthController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<HealtBar>()
                .FromComponentInNewPrefab(_healtBar)
                .UnderTransform(gameObject.transform)
                .AsSingle()
                .NonLazy();

            
        }
    }
}