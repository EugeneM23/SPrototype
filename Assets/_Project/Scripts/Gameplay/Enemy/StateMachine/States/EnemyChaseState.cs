using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyChaseState : IState
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly PlayerCharacterProvider _player;
        private readonly EnemyBlackBoard _blackboard;
        private readonly Entity _entity;

        public EnemyChaseState(
            NavMeshAgent navMeshAgent,
            PlayerCharacterProvider player,
            EnemyBlackBoard blackboard,
            Entity entity)
        {
            _navMeshAgent = navMeshAgent;
            _player = player;
            _blackboard = blackboard;
            _entity = entity;
        }

        public void OnEnter()
        {
            SetAgentSpeed(_blackboard.ChaseSpeed);
            _blackboard.IsRunning = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_player?.Character == null) return;

            _navMeshAgent.SetDestination(_player.Character.transform.position);
        }

        public void OnExit()
        {
            _blackboard.IsRunning = false;
        }

        private void SetAgentSpeed(float speed)
        {
            var agent = _entity.Get<NavMeshAgent>();
            if (agent != null)
                agent.speed = speed;
        }
    }
}