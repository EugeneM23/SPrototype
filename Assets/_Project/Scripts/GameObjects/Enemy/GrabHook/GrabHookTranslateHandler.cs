using Gameplay.Installers;
using UnityEngine;

namespace Gameplay
{
    public class GrabHookTranslateHandler : EnemyGrabHookState.IAction
    {
        private readonly Animator _animator;
        private readonly GrabHookMover _grabHookMover;

        public GrabHookTranslateHandler(Animator animator, GrabHookMover grabHookMover)
        {
            _animator = animator;
            _grabHookMover = grabHookMover;
        }

        public void EnterActions()
        {
        }

        public void ExitActions()
        {
            _animator.enabled = true;
        }

        public void ExecuteActions()
        {
            _grabHookMover.DO();
            _animator.enabled = false;
        }
    }
}