using Gameplay.Installers;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyPatrolState : IState, IInitializable
    {
        [Inject(Id = EnemyParameterID.PatrolSpeed)]
        private readonly float _patrolSpeed;

        private readonly Entity _entity;
        private readonly EnemyConditions _conditions;
        private Transform[] _waypoints;
        private int _currentWaypointIndex;
        private const float StoppingDistance = 3f;

        public EnemyPatrolState(Entity entity, EnemyConditions conditions)
        {
            _entity = entity;
            _conditions = conditions;
        }

        public void Initialize()
        {
            _waypoints = _entity.Get<EnemyPatrolPoints>().GetWaypoints();
        }

        public void Enter()
        {
            _conditions.IsWalking = true;

            if (_entity.TryGet<NavMeshAgent>(out var agent))
                agent.speed = _patrolSpeed;
        }

        public void Exit()
        {
            _conditions.IsWalking = false;
        }

        public void Update(float deltaTime)
        {
            if (_waypoints == null || _waypoints.Length == 0)
                return;

            var targetPosition = _waypoints[_currentWaypointIndex].position;
            var currentPosition = _entity.gameObject.transform.position;

            targetPosition.y = currentPosition.y; // Keep movement on XZ plane

            float distance = Vector3.Distance(currentPosition, targetPosition);

            if (distance <= StoppingDistance)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                _entity.Get<EnemyMoveComponent>().MoveTo(targetPosition);
            }
        }
    }
}