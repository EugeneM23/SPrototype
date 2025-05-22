using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CharacterAnimationController : ITickable
    {
        private readonly Animator _animator;
        private readonly CharacterConditions _conditions;

        private static readonly int IsWalkingHash = Animator.StringToHash("IsWalking");
        private static readonly int IsRunningHash = Animator.StringToHash("IsChasing");
        private static readonly int IsIdling = Animator.StringToHash("IsAidling");

        public CharacterAnimationController(Animator animator, CharacterConditions conditions)
        {
            _animator = animator;
            _conditions = conditions;
        }

        public void Tick()
        {
            _animator.SetBool(IsWalkingHash, _conditions.IsPatroling);
            _animator.SetBool(IsRunningHash, _conditions.IsChasing);
            _animator.SetBool(IsIdling, _conditions.IsAdling);
        }
    }
}