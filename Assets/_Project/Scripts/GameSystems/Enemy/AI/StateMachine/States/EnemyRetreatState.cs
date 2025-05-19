using System.Collections.Generic;
using Gameplay.Installers;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyRetreatState : IState
    {
        private readonly Entity _entity;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyBlackBoard _blackboard;
        private readonly RandomPositionGenerator _randomPosition;

        private float animationLength;
        private float timer;
        private Vector3 _destination;

        public EnemyRetreatState(NavMeshAgent navMeshAgent, EnemyBlackBoard blackboard, Entity entity,
            RandomPositionGenerator randomPosition)
        {
            _navMeshAgent = navMeshAgent;
            _blackboard = blackboard;
            _entity = entity;
            _randomPosition = randomPosition;
        }

        public void Enter()
        {
            _navMeshAgent.speed = _blackboard.ChaseSpeed;
            _blackboard.IsRunning = true;
            _blackboard.IsRetreat = true;
            _blackboard.IsBusy = true;

            _destination = _randomPosition.GetRandomPositionInSquare();
            _entity.Get<EnemyMoveComponent>().MoveTo(_destination);
        }

        public void Exit()
        {
            _blackboard.IsRunning = false;
            _blackboard.IsRetreat = false;
            _navMeshAgent.speed = _blackboard.ChaseSpeed;
        }

        public void Update(float deltaTime)
        {
            var distance = Vector3.Distance(_entity.transform.position, _destination);
            if (distance < 2f)
            {
                _blackboard.IsBusy = false;
                _blackboard.IsRetreat = false;
            }
        }
    }

    public class RandomPositionGenerator
    {
        private float squareSize = 20f;

        public Vector3 GetRandomPositionInSquare()
        {
            float halfSize = squareSize / 2f;
            float x = Random.Range(-halfSize, halfSize);
            float z = Random.Range(-halfSize, halfSize);
            float y = 0f; // или другой уровень, если нужно

            return new Vector3(x, y, z);
        }
    }
}