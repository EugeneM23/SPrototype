using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public abstract class BaseWeaponInstaller : MonoInstaller
    {
        [SerializeField] protected WeaponConfig config;
        [SerializeField] private ClipUI _clipUI;
        [SerializeField] private ReloadStatusUI _reloadStatus;

        public override void InstallBindings()
        {
            Container.Bind<WeaponConfig>().FromInstance(config).AsSingle();

            Container.Bind<WeaponShootComponent>().AsSingle();
            Container.Bind<WeaponFireController>().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponCooldownAction>().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponCameraShakeAction>().AsSingle();
            Container.BindInterfacesTo<WeaponInRangeCondition>().AsSingle();

            SetupWeaponSpecific();

            if (config.isReloadable)
            {
                SetupReload();
            }
        }

        protected abstract void SetupWeaponSpecific();

        private void SetupReload()
        {
            Container.BindInterfacesAndSelfTo<WeaponReloadComponent>().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponSootCounAction>().AsSingle();
            Container.BindInterfacesAndSelfTo<ReloadAnimationAction>().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponClipComponent>().AsSingle().WithArguments(config.clipCapacity);
            Container.BindInterfacesAndSelfTo<WeaponClipController>().AsSingle();

            if (_reloadStatus != null)
            {
                Container.BindInterfacesAndSelfTo<ReloadStatusUI>().FromComponentInNewPrefab(_reloadStatus).AsSingle()
                    .NonLazy();
                Container.BindInterfacesAndSelfTo<ReloadStatusUIPresentor>().AsSingle().NonLazy();
            }

            if (_clipUI != null)
            {
                Container.BindInterfacesAndSelfTo<ClipUI>().FromComponentInNewPrefab(_clipUI).AsSingle().NonLazy();
                Container.BindInterfacesAndSelfTo<ClipUIPresentor>().AsSingle().NonLazy();
            }
        }
    }

    [System.Serializable]
    public class RangedWeaponConfig : WeaponConfig
    {
        [Header("Ranged Stats")] public float projectileSpawnDelay = 0f;
        public int bulletSpeed = 50;
        public float scatter = 0f;
        public int projectileCount = 1;
        public float shellImpulse = 5f;
    }

    [System.Serializable]
    public class MeleeWeaponConfig : WeaponConfig
    {
        [Header("Melee Stats")] public float damageCastDelay = 0.1f;
    }

    public class WeaponConfig
    {
        [Header("Basic Stats")] public float fireRate = 1f;
        public int damage = 10;
        public float range = 10f;

        [Header("Effects")] public float shakeDuration = 0.1f;
        public float shakeMagnitude = 0.5f;

        [Header("Reload")] public bool isReloadable = false;
        public float reloadTime = 2f;
        public int clipCapacity = 30;
    }
}