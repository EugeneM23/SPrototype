using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class PatrolAction : EnemyMoveComponent.IAction
    {
        private readonly float _patrolSpeed;
        private readonly EnemyConditions _conditions;
        private readonly NavMeshAgent _agent;

        public PatrolAction(
            [Inject(Id = EnemyParameterID.PatrolSpeed)]
            float patrolSpeed,
            EnemyConditions conditions,
            NavMeshAgent agent)
        {
            _patrolSpeed = patrolSpeed;
            _conditions = conditions;
            _agent = agent;
        }

        public bool Condition() => _conditions.IsPatroling;

        public void Action()
        {
            _agent.enabled = true;
            _agent.speed = _patrolSpeed;
        }
    }
}