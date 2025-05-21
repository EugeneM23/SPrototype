using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyMoveComponent : ITickable
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

        public void Tick()
        {
            
        }
    }
}