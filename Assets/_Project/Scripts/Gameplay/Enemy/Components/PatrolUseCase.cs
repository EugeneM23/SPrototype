using Gameplay.Installers;
using UnityEngine;

namespace Gameplay
{
    public static class PatrolUseCase
    {
        private static int index;

        public static void PatrolWaypoints(Entity entity, float stoppingDistance)
        {
            Transform[] waypoints = entity.Get<EnemyPatrolPoints>().GetWaypoints();

            Vector3 currentWaypoint = waypoints[index].position;

            Vector3 characterPosition = entity.gameObject.transform.position;
            Vector3 distance = currentWaypoint - characterPosition;
            distance.y = 0;

            if (distance.sqrMagnitude <= stoppingDistance * stoppingDistance)
            {
                index = (index + 1) % waypoints.Length;
            }
            else
            {
                entity.Get<EnemyMoveComponent>().MoveTo(currentWaypoint);
            }
        }
    }
}