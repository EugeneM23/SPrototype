using AudioEngine;
using DamageNumbersPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [Header("Weapon Roots")] [SerializeField]
        private Transform _meleeWeaponRoot;

        [SerializeField] private Transform _rangeWeaponRoot;

        [Header("Weapons")] [SerializeField] private Entity _rangeWeapon;
        [SerializeField] private Entity _meleeWeapon;

        [Header("VFX")] [SerializeField] private Entity _hitEffect;
        [SerializeField] private Entity[] _deathEffects;
        [SerializeField] private Transform _hitRoot;

        [Header("Health UI")] [SerializeField] private DamageNumber _damageNumbers;
        [SerializeField] private HealtBar _healthBar;

        [Header("Layer Settings")] [SerializeField]
        private LayerMask _damageLayer;

        [Header("Raggdoll")] [SerializeField] private bool _isRaggdollEnemy;

        [Header("Character Parameters")] [SerializeField]
        private float _chaseRange = 5f;

        [SerializeField] private float _attackRange = 2f;
        [SerializeField] private float _chaseSpeed = 3f;
        [SerializeField] private float _patrolSpeed = 1f;
        [SerializeField] private float _attackRotationSpeed = 5f;
        [SerializeField] private int _health;
        [SerializeField] private bool _isPushable = true;

        [Header("SFX")] [SerializeField] private AudioEventKey _hitSound;
        [SerializeField] private AudioEventKey _stepsSound;

        public override void InstallBindings()
        {
            BindCharacterParameters();
            BindCore();
            BindWeapons();
            BindHealth();
            BindHit();
            BindSFX();

            if (_isRaggdollEnemy)
                BindRaggol();
        }

        private void BindRaggol()
        {
            Container.BindInterfacesAndSelfTo<EnemyRaggdolComponent>().AsSingle().NonLazy();
        }

        private void BindSFX()
        {
            Container.BindInterfacesAndSelfTo<FootStepSFXController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StepSFXComponent>().AsSingle().WithArguments(_stepsSound).NonLazy();

            Container.BindInterfacesAndSelfTo<HitSFXController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HitSFXComponent>().AsSingle().WithArguments(_hitSound).NonLazy();
        }

        private void BindCharacterParameters()
        {
            Container.Bind<float>().WithId(CharacterParameterID.ChaseRange).FromInstance(_chaseRange).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.AttackRange).FromInstance(_attackRange).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.ChaseSpeed).FromInstance(_chaseSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.PatrolSpeed).FromInstance(_patrolSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.AttackRotationSpeed).FromInstance(_attackRotationSpeed)
                .AsCached();
            Container.Bind<int>().WithId(CharacterParameterID.MaxHealth).FromInstance(_health).AsCached();
            Container.Bind<bool>().WithId(CharacterParameterID.IsPushable).FromInstance(_isPushable).AsCached();
        }

        private void BindCore()
        {
            // Core components
            Container.Bind<DamageLayerComponent>().AsSingle().WithArguments(_damageLayer).NonLazy();
            Container.Bind<Entity>().WithId(CharacterParameterID.CharacterEntity).FromInstance(GetComponent<Entity>())
                .AsCached().NonLazy();

            // Transform roots
            Container.Bind<Transform>().WithId(DamageRootID.MeleeWeaponRoot).FromInstance(_meleeWeaponRoot).AsCached();
            Container.Bind<Transform>().WithId(DamageRootID.RangeWeaponRoot).FromInstance(_rangeWeaponRoot).AsCached();

            // Character systems
            Container.BindInterfacesAndSelfTo<EnemyCharacterProvider>().AsSingle().NonLazy();
            Container.Bind<CharacterConditions>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterAnimationController>().AsSingle().NonLazy();
            Container.Bind<CharacterStats>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BuffManager>().AsSingle().NonLazy();

            // Enemy specific
            Container.BindInterfacesAndSelfTo<Enemy>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PushableObjectController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PushComponent>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyAttackAssistComponent>().AsSingle().NonLazy();

            // Movement and targeting
            Container.Bind<RandomPositionGenerator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TranslateComponent>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyTargetManager>().AsSingle().NonLazy();
            Container.Bind<TargetComponent>().AsSingle().NonLazy();

            // Install movement subsystem
            EnemyMovementInstaller.Install(Container);
        }

        private void BindWeapons()
        {
            // Weapon manager
            Container.BindInterfacesAndSelfTo<EnemyWeaponManager>().AsSingle().NonLazy();

            // Inventory
            Container.BindInterfacesAndSelfTo<EnemyInventory>()
                .AsSingle()
                .WithArguments(Container, _rangeWeapon, _meleeWeapon)
                .NonLazy();
        }

        private void BindHealth()
        {
            Container.BindInterfacesAndSelfTo<HealthComponent>().AsSingle().WithArguments(_health).NonLazy();
            Container.BindInterfacesAndSelfTo<TakeDamageNumberSpawController>().AsSingle().NonLazy();
            Container.Bind<DamageNumberSpawner>().AsSingle().WithArguments(_damageNumbers).NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyDeathObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TakeDamageHealthController>().AsSingle().NonLazy();
            Container.Bind<HealtBar>().FromComponentInNewPrefab(_healthBar).UnderTransform(transform).AsSingle()
                .WithArguments(_health)
                .NonLazy();
        }

        private void BindHit()
        {
            Container.Bind<HitEffectComponent>().AsSingle().WithArguments(_hitEffect, _hitRoot).NonLazy();
            Container.BindInterfacesAndSelfTo<HitEffectController>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<DeathEffectController>().AsSingle().NonLazy();
            Container.Bind<DeathEffectComponent>().AsSingle().WithArguments(_deathEffects, _hitRoot).NonLazy();
        }
    }
}