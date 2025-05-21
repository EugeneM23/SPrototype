using UnityEngine.AI;

namespace Gameplay
{
    public class BusyAction : EnemyMoveComponent.IAction
    {
        private readonly EnemyConditions _conditions;
        private readonly NavMeshAgent _agent;

        public BusyAction(EnemyConditions conditions, NavMeshAgent agent)
        {
            _conditions = conditions;
            _agent = agent;
        }

        public bool Condition() => _conditions.IsBusy;

        public void Action()
        {
            _agent.enabled = false;
            _agent.speed = 0;
        }
    }
}