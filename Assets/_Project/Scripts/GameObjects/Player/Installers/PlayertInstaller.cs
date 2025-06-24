using System.Collections.Generic;
using AudioEngine;
using DamageNumbersPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class PlayerInstaller : MonoInstaller
    {
        [Header("Health")] [SerializeField] private HealtBar healtBar;
        [SerializeField] private Vector3 _healtBarOffset;
        [SerializeField] private DamageNumber _popupPrefab;

        [Header("Combat")] [SerializeField] private Transform _weaponBone;
        [SerializeField] private LayerMask _damageLayer;
        [SerializeField] private Entity _hitEffect;
        [SerializeField] private Transform _hitRoot;

        [Header("Inventory")] [SerializeField] private int _bulletCount;
        [SerializeField] private List<Entity> _weapons;

        [Header("Settings")] [SerializeField] private float _runSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _lookAtSpeed;
        [SerializeField] private float _strafeSpeed;
        [SerializeField] private float _strafePower;
        [SerializeField] private int _health;

        [Header("SFX")] [SerializeField] private AudioEventKey _hitSound;

        [FormerlySerializedAs("_footStepsSound")] [SerializeField]
        private AudioEventKey _stepsSound;

        public override void InstallBindings()
        {
            BindCoreComponents();

            BindHealthSystem();

            BindCombatSystem();

            BindInventorySystem();

            BindSettings();

            BindSFX();

            BindPlayerCamera();

            PlayerMovementInstaller.Install(Container);
            PlayerAnimationInstaller.Install(Container);
        }

        private void BindSFX()
        {
            Container.BindInterfacesAndSelfTo<FootStepSFXController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StepSFXComponent>().AsSingle().WithArguments(_stepsSound).NonLazy();

            Container.BindInterfacesAndSelfTo<HitSFXController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HitSFXComponent>().AsSingle().WithArguments(_hitSound).NonLazy();
        }

        private void BindCoreComponents()
        {
            Container.Bind<Entity>().WithId(CharacterParameterID.CharacterEntity)
                .FromInstance(gameObject.GetComponent<Entity>()).AsCached();
            Container.BindInterfacesAndSelfTo<Player>().AsSingle().NonLazy();
            Container.Bind<TargetComponent>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BuffManager>().AsSingle().NonLazy();
        }

        private void BindPlayerCamera()
        {
            Container.BindInterfacesAndSelfTo<CameraShakeController>().AsSingle().NonLazy();
        }

        private void BindHealthSystem()
        {
            Container.BindInterfacesAndSelfTo<HealthComponent>().AsSingle().WithArguments(_health).NonLazy();
            Container.Bind<DamageNumberSpawner>().AsSingle().WithArguments(_popupPrefab).NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerDeathObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TakeDamageNumberSpawController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TakeDamageHealthController>().AsSingle().NonLazy();

            Container.Bind<HealtBar>().FromComponentInNewPrefab(healtBar).UnderTransform(transform).AsSingle()
                .WithArguments(_health)
                .NonLazy();
        }

        private void BindCombatSystem()
        {
            Container.Bind<DamageLayerComponent>().AsSingle().WithArguments(_damageLayer).NonLazy();
            Container.Bind<Transform>().WithId(DamageRootID.MeleeWeaponRoot).FromInstance(_weaponBone).AsCached();
            Container.BindInterfacesAndSelfTo<PlayerWeaponManager>().AsSingle().NonLazy();
            Container.Bind<HitEffectComponent>().AsSingle().WithArguments(_hitEffect, _hitRoot).NonLazy();
            Container.BindInterfacesAndSelfTo<HitEffectController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerImpulseComponent>().AsSingle().NonLazy();
        }

        private void BindInventorySystem()
        {
            Container.Bind<int>().WithId(WeaponParameterID.BulletCount).FromInstance(_bulletCount).AsCached();
            Container.BindInterfacesAndSelfTo<PlayerInventory>().AsSingle()
                .WithArguments(_weapons, Container, _bulletCount).NonLazy();
        }

        private void BindSettings()
        {
            Container.Bind<float>().WithId(CharacterParameterID.RunSpeed).FromInstance(_runSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.RotationSpeed).FromInstance(_rotationSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.LookAtSpeed).FromInstance(_lookAtSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.StrafeSpeed).FromInstance(_strafeSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.StrafePower).FromInstance(_strafePower).AsCached();
            Container.Bind<int>().WithId(CharacterParameterID.MaxHealth).FromInstance(_health).AsCached();
            Container.Bind<CharacterStats>().AsSingle().NonLazy();
        }
    }
}