using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class ChaseAction : EnemyMoveComponent.IAction
    {
        private readonly float _chaseSpeed;
        private readonly CharacterConditions _conditions;
        private readonly NavMeshAgent _agent;

        public ChaseAction(CharacterConditions conditions, NavMeshAgent agent)
        {
            _conditions = conditions;
            _agent = agent;
        }

        public bool Condition() => _conditions.IsChasing;

        public void Action()
        {
            _agent.enabled = true;
        }
    }
}