using System.Collections.Generic;
using Gameplay.Installers;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyRetreatState : IState
    {
        [Inject(Id = EnemyParameterID.ChaseSpeed)]
        private readonly float _chaseSpeed;

        private readonly Entity _entity;
        private readonly EnemyConditions _enemyConditions;
        private readonly RandomPositionGenerator _randomPosition;

        private float animationLength;
        private float timer;
        private Vector3 _destination;

        public EnemyRetreatState(
            EnemyConditions enemyConditions,
            Entity entity,
            RandomPositionGenerator randomPosition
        )
        {
            _enemyConditions = enemyConditions;
            _entity = entity;
            _randomPosition = randomPosition;
        }

        public void Enter()
        {
            _enemyConditions.IsChasing = true;

            _destination = _randomPosition.GetRandomPositionInSquare();
            _entity.Get<EnemyMoveComponent>().MoveTo(_destination);
        }

        public void Exit()
        {
            _enemyConditions.IsChasing = false;
        }

        public void Update(float deltaTime)
        {
            var distance = Vector3.Distance(_entity.transform.position, _destination);
            if (distance < 2f)
            {
                _enemyConditions.IsBusy = false;
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