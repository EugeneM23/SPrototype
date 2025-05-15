using DamageNumbersPro;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class EnemyHealthInstaller : MonoInstaller
    {
        [SerializeField] private DamageNumber _damageNumbers;
        [SerializeField] private int _maxHealth;
        [SerializeField] private HealtBar _healtBar;

        public override void InstallBindings()
        {
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
                .WithArguments(_maxHealth)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<HPBarPComponent>()
                .AsSingle().WithArguments(gameObject.transform, new Vector3(0f, 4, 0f))
                .NonLazy();
        }
    }
}