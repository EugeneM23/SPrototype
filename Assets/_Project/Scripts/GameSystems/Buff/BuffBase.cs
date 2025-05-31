using System;
using UnityEngine;

namespace Gameplay
{
    public abstract class BuffBase
    {
        public event Action OnApply;
        public event Action OnDiscard;
        public event Action<int> OnStack;

        private readonly Entity rageUi;
        protected readonly Entity target;
        private readonly bool isStackable;
        private readonly bool isTimed;
        private readonly float duration;
        private readonly int maxStack;

        public float StartTime { get; private set; }
        protected int stackCount = 1;

        public bool IsStackable => isStackable;
        public bool IsTimed => isTimed;
        public int StackCount => stackCount;

        protected BuffBase(Entity target, Entity rageUi, bool isStackable = false, bool isTimed = false,
            float duration = 0f, int maxStack = 1)
        {
            this.target = target;
            this.isStackable = isStackable;
            this.isTimed = isTimed;
            this.duration = duration;
            this.maxStack = maxStack;
            this.rageUi = rageUi;
        }

        public virtual void Apply()
        {
            if (isTimed)
                StartTime = Time.time;
            OnApply?.Invoke();
        }

        public virtual void Tick()
        {
        }

        public virtual void Discard()
        {
            OnDiscard?.Invoke();
        }

        public bool IsExpired() => isTimed && (Time.time - StartTime) >= duration;

        public void AddStack()
        {
            if (stackCount > maxStack) return;
            stackCount++;
            OnStackAdded();
        }

        public void RefreshTimer()
        {
            if (isTimed)
                StartTime = Time.time;
        }

        protected virtual void OnStackAdded() => OnStack?.Invoke(stackCount);
    }
}