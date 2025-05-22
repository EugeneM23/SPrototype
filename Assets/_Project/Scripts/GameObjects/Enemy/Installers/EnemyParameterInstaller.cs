using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyParameterInstaller : MonoInstaller
    {
        [SerializeField] private float _chaseRange;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _chaseSpeed;
        [SerializeField] private float _patrolSpeed;
        [SerializeField] private float _attackRotationSpeed;
        [SerializeField] private int _damage;
        [SerializeField] private int _health;
        [SerializeField] private bool _isPushable;

        public override void InstallBindings()
        {
            Container.Bind<float>().WithId(EnemyParameterID.ChaseRange).FromInstance(_chaseRange).AsCached();
            Container.Bind<float>().WithId(EnemyParameterID.AttackRange).FromInstance(_attackRange).AsCached();
            Container.Bind<float>().WithId(EnemyParameterID.ChaseSpeed).FromInstance(_chaseSpeed).AsCached();
            Container.Bind<float>().WithId(EnemyParameterID.PatrolSpeed).FromInstance(_patrolSpeed).AsCached();
            Container.Bind<float>().WithId(EnemyParameterID.AttackRotationSpeed).FromInstance(_attackRotationSpeed)
                .AsCached();
            Container.Bind<int>().WithId(EnemyParameterID.Damage).FromInstance(_damage).AsCached();
            Container.Bind<int>().WithId(EnemyParameterID.Health).FromInstance(_health).AsCached();
            Container.Bind<bool>().WithId(EnemyParameterID.IsPushable).FromInstance(_isPushable).AsCached();
        }
    }
}