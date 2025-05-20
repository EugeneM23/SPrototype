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
        private readonly EnemyConditions _conditions;
        private readonly Entity _entity;
        private Transform _target;

        public EnemyChaseState(
            NavMeshAgent navMeshAgent,
            EnemyConditions conditions,
            Entity entity)
        {
            _navMeshAgent = navMeshAgent;
            _conditions = conditions;
            _entity = entity;
        }

        public void Enter()
        {
            SetAgentSpeed(_chaseSpeed);
            _conditions.IsRunning = true;
        }

        public void Update(float deltaTime)
        {
            _target = _entity.Get<TargetComponent>().Target.transform;

            if (_target == null) return;

            _navMeshAgent.SetDestination(_target.position);
        }

        public void Exit()
        {
            _conditions.IsRunning = false;
        }

        private void SetAgentSpeed(float speed)
        {
            var agent = _entity.Get<NavMeshAgent>();
            if (agent != null)
                agent.speed = speed;
        }
    }
}