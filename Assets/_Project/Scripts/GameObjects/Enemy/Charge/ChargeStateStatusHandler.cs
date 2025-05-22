using UnityEngine.AI;

namespace Gameplay
{
    public class ChargeStateStatusHandler : EnemyChargeState.IAction
    {
        private readonly CharacterConditions _conditions;
        private readonly NavMeshAgent _navMeshAgent;

        public ChargeStateStatusHandler(CharacterConditions conditions, NavMeshAgent navMeshAgent)
        {
            _conditions = conditions;
            _navMeshAgent = navMeshAgent;
        }

        public void EnterActions()
        {
            _conditions.IsBusy = true;
            _conditions.CanPush = false;
            _navMeshAgent.enabled = false;
        }

        public void ExitActions()
        {
            _conditions.CanPush = true;
            _navMeshAgent.enabled = true;
            _conditions.IsBusy = false;
        }

        public void ExecuteActions()
        {
        }
    }
}