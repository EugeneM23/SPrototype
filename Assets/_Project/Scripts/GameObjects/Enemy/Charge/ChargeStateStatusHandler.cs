using UnityEngine.AI;

namespace Gameplay
{
    public class ChargeStateStatusHandler : EnemyChargeState.IAction
    {
        private readonly EnemyBlackBoard _blackBoard;
        private readonly NavMeshAgent _navMeshAgent;

        public ChargeStateStatusHandler(EnemyBlackBoard blackBoard, NavMeshAgent navMeshAgent)
        {
            _blackBoard = blackBoard;
            _navMeshAgent = navMeshAgent;
        }

        public void EnterActions()
        {
            _blackBoard.IsBusy = true;
            _blackBoard.IsAttacking = true;
            _blackBoard.CanPush = false;
            _navMeshAgent.enabled = false;
        }

        public void ExitActions()
        {
            _blackBoard.CanPush = true;
            _navMeshAgent.enabled = true;
            _blackBoard.IsBusy = false;
            _blackBoard.IsAttacking = false;
        }

        public void ExecuteActions()
        {
        }
    }
}