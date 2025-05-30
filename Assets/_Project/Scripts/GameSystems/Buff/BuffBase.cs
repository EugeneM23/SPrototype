using UnityEngine;

namespace Gameplay
{
    public abstract class BuffBase
    {
        protected readonly Entity target;
        private readonly bool isStackable;
        private readonly bool isTimed;
        private readonly float duration;
        private readonly int maxStack;

        private float startTime;
        protected int stackCount = 1;

        public bool IsStackable => isStackable;
        public bool IsTimed => isTimed;
        public int StackCount => stackCount;

        protected BuffBase(Entity target, bool isStackable = false, bool isTimed = false,
            float duration = 0f, int maxStack = 1)
        {
            this.target = target;
            this.isStackable = isStackable;
            this.isTimed = isTimed;
            this.duration = duration;
            this.maxStack = maxStack;
        }

        public virtual void Apply()
        {
            if (isTimed)
                startTime = Time.time;
        }

        public virtual void Tick()
        {
        }

        public abstract void Discard();

        public bool IsExpired() => isTimed && (Time.time - startTime) >= duration;

        public void AddStack()
        {
            if (stackCount > maxStack) return;
            stackCount++;
            OnStackAdded();
        }

        public void RefreshTimer()
        {
            if (isTimed)
                startTime = Time.time;
        }

        protected virtual void OnStackAdded()
        {
        }
    }
}