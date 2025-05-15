using UnityEngine;

namespace Gameplay
{
    public class EnemyPatrolPoints : MonoBehaviour
    {
        [SerializeField] private Transform[] _patrolPoints;

        public Transform[] GetWaypoints()
        {
            return _patrolPoints;
        }
    }
}