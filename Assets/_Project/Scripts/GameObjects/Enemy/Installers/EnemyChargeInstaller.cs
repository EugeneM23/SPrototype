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

        [SerializeField] private float _chargeDuration;
        [SerializeField] private int _chargeDamage;
        [SerializeField] private float _damageCastDuration;
        [SerializeField] private float _damageCastRadius;
        [SerializeField] private int _chargeRotaionSpeed;
        [SerializeField] private float _chargeRotaionDuration;
        [SerializeField] private float _chargeMoveDuration;
        [SerializeField] private float _chargeMoveSpeed;

        [Inject] private readonly Entity _entity;

        public override void InstallBindings()
        {
            

            Container
                .Bind<ChargeEffectMarker>()
                .FromComponentInNewPrefab(chargeEffectMarker)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyChargeState>()
                .AsSingle()
                .WithArguments(_chargeDuration)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyChargeAttackDecision>()
                .AsSingle()
                .NonLazy();


            Container
                .BindInterfacesAndSelfTo<ChargeEffectsHandler>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ChargeAnimationHandler>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ChargeStateStatusHandler>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ChargeRaySensor>()
                .AsSingle()
                .WithArguments(_detectionEnviromentLayer)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ChargeRotationHandler>()
                .AsSingle()
                .WithArguments(_chargeRotaionSpeed, _chargeRotaionDuration)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ChargeTranslateHandler>()
                .AsSingle()
                .WithArguments(_chargeMoveDuration, _chargeMoveSpeed)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ChargeCompletionHandler>()
                .AsSingle()
                .WithArguments(_chargeDuration)
                .NonLazy();
        }
    }
}