using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyChargeInstaller", menuName = "Installers/AI/EnemyChargeInstaller")]
    public class EnemyChargeInstaller : ScriptableObjectInstaller<EnemyChargeInstaller>
    {
        [SerializeField] private ChargeEffectMarker chargeEffectMarker;
        [SerializeField] private LayerMask _detectionEnviromentLayer;

        [SerializeField] private LayerMask _damageLayer;
        [SerializeField] private int _chargeDamage;
        [SerializeField] private float _damageCastDuration;
        [SerializeField] private float _damageCastRadius;
        [Inject] private readonly Entity _entity;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<ChargeDamageCast>()
                .AsSingle()
                .WithArguments(new DamageCastParams(
                    _chargeDamage,
                    _damageCastRadius,
                    _damageCastDuration,
                    _damageLayer,
                    _entity.transform))
                .NonLazy();

            Container
                .Bind<ChargeEffectMarker>()
                .FromComponentInNewPrefab(chargeEffectMarker)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyChargeState>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyChargeAttackReasoner>()
                .AsSingle()
                .NonLazy();


            Container
                .BindInterfacesAndSelfTo<SpawnChargeEffectsComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<AnimationChargeComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ChargeRaySensor>()
                .AsSingle()
                .WithArguments(_detectionEnviromentLayer)
                .NonLazy();
        }
    }
}