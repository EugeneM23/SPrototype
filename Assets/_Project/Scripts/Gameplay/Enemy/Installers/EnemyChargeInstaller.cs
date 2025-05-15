using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyChargeInstaller", menuName = "Installers/AI/EnemyChargeInstaller")]
    public class EnemyChargeInstaller : ScriptableObjectInstaller<EnemyChargeInstaller>
    {
        [SerializeField] private ChargeEffect _chargeEffect;
        [SerializeField] private LayerMask _detectionLayer;

        public override void InstallBindings()
        {
            Container.Bind<ChargeEffect>().FromComponentInNewPrefab(_chargeEffect).AsSingle().NonLazy();

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