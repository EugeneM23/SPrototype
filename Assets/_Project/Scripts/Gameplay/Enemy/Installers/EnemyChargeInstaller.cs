using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyChargeInstaller", menuName = "Installers/AI/EnemyChargeInstaller")]
    public class EnemyChargeInstaller : ScriptableObjectInstaller<EnemyChargeInstaller>
    {
        [FormerlySerializedAs("_chargeEffect")] [SerializeField] private ChargeEffectMarker chargeEffectMarker;
        [SerializeField] private LayerMask _detectionLayer;

        public override void InstallBindings()
        {
            Container.Bind<ChargeEffectMarker>().FromComponentInNewPrefab(chargeEffectMarker).AsSingle().NonLazy();

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
                .WithArguments(_detectionLayer)
                .NonLazy();
        }
    }
}