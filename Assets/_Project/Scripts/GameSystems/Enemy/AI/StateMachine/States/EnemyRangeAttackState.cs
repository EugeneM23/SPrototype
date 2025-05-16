using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyRangeAttackState : IState, IInitializable
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyBlackBoard _blackboard;
        private readonly Animator _animator;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly DelayedAction _delayedAction;
        private readonly EnemyCharacterProvider _characterProvider;
        private readonly Enemy _enemy;

        private readonly Dictionary<string, AnimationClip> _animationClips = new();

        private float _animationLength;
        private float _timer;

        private const string AttackAnimationName = "Attack_Left";

        public EnemyRangeAttackState(
            NavMeshAgent navMeshAgent,
            EnemyBlackBoard blackboard,
            Animator animator,
            EnemyAttackAssistComponent assistComponent,
            DelayedAction delayedAction, EnemyCharacterProvider characterProvider, Enemy enemy)
        {
            _navMeshAgent = navMeshAgent;
            _blackboard = blackboard;
            _animator = animator;
            _assistComponent = assistComponent;
            _delayedAction = delayedAction;
            _characterProvider = characterProvider;
            _enemy = enemy;
        }

        public void Initialize()
        {
            foreach (var clip in _animator.runtimeAnimatorController.animationClips)
                _animationClips.TryAdd(clip.name, clip);
        }

        public void OnEnter()
        {
            _navMeshAgent.enabled = false;
            _blackboard.IsBusy = true;

            _animationLength = PlayAttackAnimation();

            _delayedAction.Schedule(_animationLength - 0.1f, () => _blackboard.IsBusy = false);
            _assistComponent.RotateToTarget(_blackboard.Target, _blackboard.Enemy, 10, _animationLength);
        }

        public void OnExit()
        {
            _navMeshAgent.enabled = true;
            _blackboard.IsBusy = false;
        }

        public void OnUpdate(float deltaTime)
        {
            _timer -= deltaTime;

            if (_timer <= 0f)
                PlayAttackAnimation();
        }

        private float PlayAttackAnimation()
        {
            if (!_animationClips.TryGetValue(AttackAnimationName, out var clip))
                return 0;

            _animator.Play(AttackAnimationName);

            _animationLength = clip.length;
            _timer = _animationLength;

            return _animationLength;
        }
    }
}