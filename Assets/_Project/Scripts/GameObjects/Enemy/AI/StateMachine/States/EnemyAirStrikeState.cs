using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyAirStrikeState : IState
    {
        private const float AirStrikeDelay = 2f;
        private const int RotationSpeed = 5;
        private const float RotationDuration = 2f;
        private const string AirStrikePrefabPath = "Prefabs/AirStrike";
        private const string ChargeAnimation = "Charge";

        private readonly EnemyBlackBoard _blackBoard;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly Animator _animator;
        private readonly PlayerCharacterProvider _playerCharacterProvider;
        private readonly DiContainer _container;

        private float _timer;
        private bool _isComplete;

        public EnemyAirStrikeState(
            EnemyBlackBoard blackBoard,
            NavMeshAgent navMeshAgent,
            EnemyAttackAssistComponent assistComponent,
            Animator animator,
            PlayerCharacterProvider playerCharacterProvider, DiContainer container)
        {
            _blackBoard = blackBoard;
            _navMeshAgent = navMeshAgent;
            _assistComponent = assistComponent;
            _animator = animator;
            _playerCharacterProvider = playerCharacterProvider;
            _container = container;
        }

        public void Enter()
        {
            _navMeshAgent.enabled = false;
            _isComplete = false;
            _timer = AirStrikeDelay;

            PlayChargeAnimation();
            SpawnAirStrike();
            SetBlackBoardFlags(isBusy: true, isAttacking: true, canPush: false);

            _assistComponent.RotateToTarget(_blackBoard.Target, _blackBoard.Enemy, RotationSpeed, RotationDuration);
        }

        public void Update(float deltaTime)
        {
            if (_isComplete)
                return;

            _timer -= deltaTime;
            if (_timer <= 0f)
            {
                _isComplete = true;
                _blackBoard.IsBusy = false;
            }
        }

        public void Exit()
        {
            _navMeshAgent.enabled = true;
            _timer = AirStrikeDelay;

            SetBlackBoardFlags(isBusy: false, isAttacking: false, canPush: true);
        }

        private void PlayChargeAnimation()
        {
            _animator.Play(ChargeAnimation);
        }

        private void SpawnAirStrike()
        {
            var airStrikePrefab = Resources.Load<GameObject>(AirStrikePrefabPath);
            Vector3 targetPosition = _playerCharacterProvider.Character.transform.position;
            GameObject go = _container.InstantiatePrefab(airStrikePrefab);
            go.transform.SetParent(null);
            go.transform.position = targetPosition;
        }

        private void SetBlackBoardFlags(bool isBusy, bool isAttacking, bool canPush)
        {
            _blackBoard.IsBusy = isBusy;
            _blackBoard.IsAttacking = isAttacking;
            _blackBoard.CanPush = canPush;
        }
    }
}