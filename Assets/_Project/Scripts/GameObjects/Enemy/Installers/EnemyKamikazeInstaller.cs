using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyKamikazeInstaller", menuName = "Installers/AI/EnemyKamikazeInstaller")]
    public class EnemyKamikazeInstaller : ScriptableObjectInstaller<EnemyKamikazeInstaller>
    {
        [SerializeField] private float _kamikazeDistance;
        [SerializeField] private int _damage;
        [SerializeField] private int _impulsePower;
        [SerializeField] private float _impulseDuration;
        [SerializeField] private Entity[] _bodyParts;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyKamikazeDecision>()
                .AsSingle()
                .WithArguments(_kamikazeDistance)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyKamikazeState>()
                .AsSingle()
                .WithArguments(_damage, _impulsePower, _impulseDuration)
                .NonLazy();
            Container
                .BindInterfacesAndSelfTo<EnemySpawnBodyPartComponent>()
                .AsSingle()
                .WithArguments(_bodyParts)
                .NonLazy();
        }
    }
}