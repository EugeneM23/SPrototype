using Gameplay.Installers;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyPatrolState : IState, IInitializable
    {
        [Inject(Id = CharacterParameterID.PatrolSpeed)]
        private readonly float _patrolSpeed;

        private readonly Entity _entity;
        private readonly CharacterConditions _conditions;
        private Transform[] _waypoints;
        private int _currentWaypointIndex;
        private const float StoppingDistance = 3f;

        public EnemyPatrolState(
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity entity,
            CharacterConditions conditions
        )
        {
            _entity = entity;
            _conditions = conditions;
        }

        public void Initialize()
        {
            if (_entity.TryGet<EnemyPatrolPoints>(out EnemyPatrolPoints points))
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

        public void SetWaypoints(EnemyPatrolPoints waypoints)
        {
            _waypoints = waypoints.GetWaypoints();
        }
    }
}