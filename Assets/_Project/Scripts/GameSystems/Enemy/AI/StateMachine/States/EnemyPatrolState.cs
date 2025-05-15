using Gameplay.Installers;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyPatrolState : IState, IInitializable
    {
        private readonly Entity _entity;
        private readonly EnemyBlackBoard _blackboard;

        private Transform[] _waypoints;
        private int _currentWaypointIndex;
        private const float StoppingDistance = 3f;

        public EnemyPatrolState(Entity entity, EnemyBlackBoard blackboard)
        {
            _entity = entity;
            _blackboard = blackboard;
        }

        public void Initialize()
        {
            _waypoints = _entity.Get<EnemyPatrolPoints>().GetWaypoints();
        }

        public void OnEnter()
        {
            _blackboard.IsWalking = true;

            if (_entity.TryGet<NavMeshAgent>(out var agent)) 
                agent.speed = _blackboard.PatrolSpeed;
        }

        public void OnExit()
        {
            _blackboard.IsWalking = false;
        }

        public void OnUpdate(float deltaTime)
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