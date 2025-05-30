using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BuffRunSpeed : BuffBase, ITickable
    {
        private readonly float speedPerStack;
        private float _timer;
        private int _damage = 10;

        public BuffRunSpeed(Entity target, float speedPerStack, bool isStackable = false,
            bool isTimed = false, float duration = 0f, int maxStack = 1)
            : base(target, isStackable, isTimed, duration, maxStack)
        {
            this.speedPerStack = speedPerStack;
        }

        public override void Apply()
        {
            base.Apply();
            target.Get<PlayerMoveComponent>().AddSpeed(speedPerStack);
        }

        public override void Discard()
        {
            target.Get<PlayerMoveComponent>().AddSpeed(speedPerStack * stackCount * -1);
        }

        protected override void OnStackAdded()
        {
            target.Get<PlayerMoveComponent>().AddSpeed(speedPerStack);
        }
    }
}