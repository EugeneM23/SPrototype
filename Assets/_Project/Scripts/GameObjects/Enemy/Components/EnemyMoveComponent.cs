using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Installers
{
    public class EnemyMoveComponent
    {
        private readonly NavMeshAgent _agent;

        public EnemyMoveComponent(NavMeshAgent agent)
        {
            _agent = agent;
        }

        public void MoveTo(Vector3 destination)
        {
            _agent.SetDestination(destination);
        }
    }
}