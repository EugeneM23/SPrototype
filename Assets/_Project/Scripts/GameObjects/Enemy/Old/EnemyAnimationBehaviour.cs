using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAnimationBehaviour : ITickable
    {
        private readonly Animator _animator;
        private readonly EnemyConditions _blackboard;

        private static readonly int IsWalkingHash = Animator.StringToHash("IsWalking");
        private static readonly int IsRunningHash = Animator.StringToHash("IsRunning");
        private static readonly int IsAttackingHash = Animator.StringToHash("IsAttaking");

        public EnemyAnimationBehaviour(Animator animator, EnemyConditions blackboard)
        {
            _animator = animator;
            _blackboard = blackboard;
        }

        public void Tick()
        {
            _animator.SetBool(IsWalkingHash, _blackboard.IsWalking);
            _animator.SetBool(IsRunningHash, _blackboard.IsRunning);
            //_animator.SetBool(IsAttackingHash, _conditions.IsAttacking);
        }
    }
}