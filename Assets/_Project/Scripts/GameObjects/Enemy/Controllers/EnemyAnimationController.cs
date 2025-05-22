using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyAnimationController : ITickable
    {
        private readonly Animator _animator;
        private readonly EnemyConditions _blackboard;

        private static readonly int IsWalkingHash = Animator.StringToHash("IsWalking");
        private static readonly int IsRunningHash = Animator.StringToHash("IsRunning");

        public EnemyAnimationController(Animator animator, EnemyConditions blackboard)
        {
            _animator = animator;
            _blackboard = blackboard;
        }

        public void Tick()
        {
            _animator.SetBool(IsWalkingHash, _blackboard.IsPatroling);
            _animator.SetBool(IsRunningHash, _blackboard.IsChasing);
        }
    }
}