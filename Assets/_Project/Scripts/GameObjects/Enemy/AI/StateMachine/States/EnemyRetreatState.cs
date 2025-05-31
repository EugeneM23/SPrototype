using System.Collections.Generic;
using Gameplay.Installers;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyRetreatState : IState
    {
        [Inject(Id = CharacterParameterID.ChaseSpeed)]
        private readonly float _chaseSpeed;

        private readonly Entity _entity;
        private readonly CharacterConditions _characterConditions;
        private readonly RandomPositionGenerator _randomPosition;

        private float animationLength;
        private float timer;
        private Vector3 _destination;

        public EnemyRetreatState(
            CharacterConditions characterConditions,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity entity,
            RandomPositionGenerator randomPosition
        )
        {
            _characterConditions = characterConditions;
            _entity = entity;
            _randomPosition = randomPosition;
        }

        public void Enter()
        {
            _characterConditions.IsChasing = true;

            _destination = _randomPosition.GetRandomPositionInSquare();
            _entity.Get<EnemyMoveComponent>().Move(_destination);
        }

        public void Exit()
        {
            _characterConditions.IsChasing = false;
        }

        public void Update(float deltaTime)
        {
            var distance = Vector3.Distance(_entity.transform.position, _destination);
            if (distance < 2f)
            {
                _characterConditions.IsBusy = false;
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