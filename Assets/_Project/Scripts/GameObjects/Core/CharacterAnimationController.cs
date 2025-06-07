using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CharacterAnimationController : ITickable
    {
        private readonly Animator _animator;
        private readonly CharacterConditions _conditions;

        private static readonly int WalkingHash = Animator.StringToHash("IsWalking");
        private static readonly int RunningHash = Animator.StringToHash("IsChasing");
        private static readonly int IdlingHash = Animator.StringToHash("IsAidling");

        public CharacterAnimationController(Animator animator, CharacterConditions conditions)
        {
            _animator = animator;
            _conditions = conditions;
        }

        public void Tick()
        {
            _animator.SetBool(WalkingHash, _conditions.IsPatroling);
            _animator.SetBool(RunningHash, _conditions.IsChasing);
            _animator.SetBool(IdlingHash, _conditions.IsIdling);
        }
    }
}