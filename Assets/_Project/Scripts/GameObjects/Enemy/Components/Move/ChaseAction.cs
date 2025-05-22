using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class ChaseAction : EnemyMoveComponent.IAction
    {
        private readonly float _chaseSpeed;
        private readonly CharacterConditions _conditions;
        private readonly NavMeshAgent _agent;

        public ChaseAction(
            [Inject(Id = EnemyParameterID.ChaseSpeed)]
            float chaseSpeed,
            CharacterConditions conditions,
            NavMeshAgent agent)
        {
            _chaseSpeed = chaseSpeed;
            _conditions = conditions;
            _agent = agent;
        }

        public bool Condition() => _conditions.IsChasing;

        public void Action()
        {
            _agent.enabled = true;
            _agent.speed = _chaseSpeed;
        }
    }
}