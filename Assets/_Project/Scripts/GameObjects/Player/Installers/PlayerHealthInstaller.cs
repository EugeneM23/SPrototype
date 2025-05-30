using DamageNumbersPro;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class
        PlayerHealthInstaller : Installer<int, Vector3, Transform, HealtBar, DamageNumber, PlayerHealthInstaller>
    {
        [Inject] private HealtBar _healtBar;
        [Inject] private Transform _parent;
        [Inject] private Vector3 _hpBarOffset;
        [Inject] private int _maxHealth;
        [Inject] private DamageNumber _damageNumber;

        public override void InstallBindings()
        {
            Container.Bind<int>().WithId(CharacterParameterID.Health).FromInstance(_maxHealth).AsCached();

            Container
                .BindInterfacesAndSelfTo<HealthComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<DamageNumberSpawner>()
                .AsSingle()
                .WithArguments(_damageNumber)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerDeathObserver>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<TakeDamageNumberSpawController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<TakeDamageHealthController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<HealtBar>()
                .FromComponentInNewPrefab(_healtBar)
                .UnderTransform(_parent)
                .AsSingle()
                .WithArguments(_maxHealth)
                .NonLazy();
        }
    }
}