using Gameplay.Installers;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyPatrolState : IState, IInitializable
    {
        private readonly CharacterStats _stats;
        private readonly CharacterConditions _conditions;
        private Transform[] _waypoints;
        private int _currentWaypointIndex;
        private const float StoppingDistance = 3f;

        public EnemyPatrolState(CharacterConditions conditions, CharacterStats stats)
        {
            _conditions = conditions;
            _stats = stats;
        }

        public void Initialize()
        {
            if (_stats.CharacterEntity.TryGet<EnemyPatrolPoints>(out EnemyPatrolPoints points))
                _waypoints = points.GetWaypoints();
        }

        public void Enter()
        {
            _conditions.IsPatroling = true;
        }

        public void Exit()
        {
            _conditions.IsPatroling = false;
        }

        public void Update(float deltaTime)
        {
            if (_waypoints == null || _waypoints.Length == 0)
                return;

            var targetPosition = _waypoints[_currentWaypointIndex].position;
            var currentPosition = _stats.CharacterEntity.gameObject.transform.position;

            targetPosition.y = currentPosition.y; // Keep movement on XZ plane

            float distance = Vector3.Distance(currentPosition, targetPosition);

            if (distance <= StoppingDistance)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                _stats.CharacterEntity.Get<EnemyMoveComponent>().Move(targetPosition);
            }
        }

        public void SetWaypoints(EnemyPatrolPoints waypoints)
        {
            _waypoints = waypoints.GetWaypoints();
        }
    }
}