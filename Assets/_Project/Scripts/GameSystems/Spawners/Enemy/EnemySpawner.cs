using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemySpawner : IInitializable, ITickable
    {
        private readonly Entity _enemyPrefab;
        private readonly EnemyPatrolPoints _waypoints;
        private readonly GameFactory _spawner;
        private Vector3 _spawnPosition;

        private float _spawnTime;
        private bool IsCycle;
        private int _startCount;

        public EnemySpawner(
            GameFactory spawner,
            Vector3 spawnPosition,
            bool isCycle,
            float spawnTime,
            int startCount,
            Entity enemyPrefab, EnemyPatrolPoints waypoints)
        {
            _spawner = spawner;
            _spawnPosition = spawnPosition;
            IsCycle = isCycle;
            _spawnTime = spawnTime;
            _startCount = startCount;
            _enemyPrefab = enemyPrefab;
            _waypoints = waypoints;
        }

        public void Initialize()
        {
            for (int i = 0; i < _startCount; i++)
            {
                var go = _spawner.Create(_enemyPrefab);
                go.transform.position = _spawnPosition;
                go.Get<EnemyPatrolState>().SetWaypoints(_waypoints);
            }
        }

        public void Tick()
        {
            if (IsCycle)
            {
                _spawnTime -= Time.deltaTime;
                if (_spawnTime <= 0)
                {
                    var go = _spawner.Create(_enemyPrefab);
                    go.transform.position = _spawnPosition;
                    go.Get<EnemyPatrolState>().SetWaypoints(_waypoints);
                    go.Get<HealthComponent>();
                    _spawnTime = 3;
                }
            }
        }
    }
}