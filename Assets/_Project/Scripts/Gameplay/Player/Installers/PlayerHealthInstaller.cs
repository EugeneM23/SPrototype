using DamageNumbersPro;
using Modules;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class
        PlayerHealthInstaller : Installer<int, Vector3, Transform, HealtBar, DamageNumber, PlayerHealthInstaller>
    {
        [Inject] Entity _player;
        [Inject] private HealtBar _healtBar;
        [Inject] private Transform _parent;
        [Inject] private Vector3 _hpBarOffset;
        [Inject] private int _maxHealth;
        [Inject] private DamageNumber _damageNumber;

        public override void InstallBindings()
        {
            Container
                .Bind<DamageNumberSpawner>()
                .AsSingle()
                .WithArguments(_damageNumber)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerDeathController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<TakeDamageNumberSpawController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<TakeDamageEffectSpawnController>()
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

            Container
                .BindInterfacesAndSelfTo<HPBarPComponent>()
                .AsSingle().WithArguments(_hpBarOffset, _parent)
                .NonLazy();
        }
    }
}