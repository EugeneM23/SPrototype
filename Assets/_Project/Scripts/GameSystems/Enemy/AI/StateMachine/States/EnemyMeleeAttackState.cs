using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyMeleeAttackState : IState, IInitializable
    {
        private readonly DelayedAction _attackSwitcher;
        private readonly EnemyBlackBoard _blackboard;
        private readonly Animator _animator;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly NavMeshAgent _navMeshAgent;

        private readonly Dictionary<string, AnimationClip> _animationClips = new();
        private float _animationLength;
        private float _timer;

        private const string AttackAnimationName = "Attack_Right";

        public EnemyMeleeAttackState(
            EnemyBlackBoard blackboard,
            Animator animator,
            EnemyAttackAssistComponent assistComponent,
            DelayedAction attackSwitcher,
            NavMeshAgent navMeshAgent)
        {
            _blackboard = blackboard;
            _animator = animator;
            _assistComponent = assistComponent;
            _attackSwitcher = attackSwitcher;
            _navMeshAgent = navMeshAgent;
        }

        public void Initialize()
        {
            foreach (var clip in _animator.runtimeAnimatorController.animationClips)
                _animationClips.TryAdd(clip.name, clip);
        }

        public void OnEnter()
        {
            _navMeshAgent.enabled = false;
            SetBlackboardState(isBusy: true, isAttacking: true);
            PlayAttackAnimation();
        }

        public void OnExit()
        {
            _navMeshAgent.enabled = true;
            SetBlackboardState(isBusy: false, isAttacking: false);
        }

        public void OnUpdate(float deltaTime)
        {
            _timer -= deltaTime;
            if (_timer <= 0f)
                PlayAttackAnimation();
        }

        private void PlayAttackAnimation()
        {
            _animator.Play(AttackAnimationName);

            if (_animationClips.TryGetValue(AttackAnimationName, out var clip))
            {
                _animationLength = clip.length;
                _timer = _animationLength;

                _assistComponent.RotateToTarget(_blackboard.Target, _blackboard.Enemy, 10, _animationLength);
                _attackSwitcher.Schedule(_animationLength - 0.01f, () => _blackboard.IsBusy = false);
            }
        }

        private void SetBlackboardState(bool isBusy, bool isAttacking)
        {
            _blackboard.IsBusy = isBusy;
            _blackboard.IsAttacking = isAttacking;
        }
    }
}