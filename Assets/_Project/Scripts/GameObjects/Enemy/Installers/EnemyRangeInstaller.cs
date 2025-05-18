using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyRangeInstaller", menuName = "Installers/AI/EnemyRangeInstaller")]
    public class EnemyRangeInstaller : ScriptableObjectInstaller<EnemyRangeInstaller>
    {
        [SerializeField] private GameObject _weaponPrefab;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyRangeReasoner>()
                .AsSingle()
                .NonLazy();


            Container
                .BindInterfacesAndSelfTo<EnemyRangeAttackState>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<RangeWeaponManager>()
                .AsSingle()
                .WithArguments(_weaponPrefab)
                .NonLazy();

            
        }
    }

    public class RangeProjectileSpawn : IInitializable
    {
        private readonly AnimationEventProvider _animationEvent;
        private readonly WeaponShootComponent _weaponShootComponent;

        public RangeProjectileSpawn(AnimationEventProvider animationEvent, WeaponShootComponent weaponShootComponent)
        {
            _animationEvent = animationEvent;
            _weaponShootComponent = weaponShootComponent;
        }

        public void Initialize()
        {
            _animationEvent.OnCall += SpawnProjectile;
        }

        private void SpawnProjectile(string eventName)
        {
            if (eventName == "Shoot")
                _weaponShootComponent.Shoot();
        }
    }
}