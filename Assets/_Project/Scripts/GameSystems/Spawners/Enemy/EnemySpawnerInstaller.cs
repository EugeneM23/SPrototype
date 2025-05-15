using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _patrolPoints;
        [SerializeField] private Entity _enemyPrefab;
        [SerializeField] private bool _isCycle;
        [SerializeField] private float _spawnTime;
        [SerializeField] private int _startCount;

        public override void InstallBindings()
        {
            Container
                .Bind<EnemyPatrolPoints>()
                .FromComponentOn(_patrolPoints)
                .AsSingle();

            Container
                .BindMemoryPool<Entity, EnemyPool>()
                .FromComponentInNewPrefab(_enemyPrefab);

            Container
                .BindInterfacesAndSelfTo<EnemySpawner>()
                .AsSingle()
                .WithArguments(transform.position, _isCycle, _spawnTime, _startCount)
                .NonLazy();
        }
    }
}