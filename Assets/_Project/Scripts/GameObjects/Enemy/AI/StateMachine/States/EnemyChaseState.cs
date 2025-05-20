using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyChaseState : IState
    {
        [Inject(Id = EnemyParameterID.ChaseSpeed)]
        private readonly float _chaseSpeed;
        
        private readonly NavMeshAgent _navMeshAgent;
        private readonly PlayerCharacterProvider _player;
        private readonly EnemyConditions _blackboard;
        private readonly Entity _entity;

        public EnemyChaseState(
            NavMeshAgent navMeshAgent,
            PlayerCharacterProvider player,
            EnemyConditions blackboard,
            Entity entity)
        {
            _navMeshAgent = navMeshAgent;
            _player = player;
            _blackboard = blackboard;
            _entity = entity;
        }

        public void Enter()
        {
            SetAgentSpeed(_chaseSpeed);
            _blackboard.IsRunning = true;
        }

        public void Update(float deltaTime)
        {
            if (_player?.Character == null) return;

            _navMeshAgent.SetDestination(_player.Character.transform.position);
        }

        public void Exit()
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