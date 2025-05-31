using System;
using UnityEngine;

namespace Gameplay
{
    public abstract class BuffBase
    {
        public event Action OnApply;
        public event Action OnDiscard;
        public event Action<int> OnStack;

        protected Entity target;
        protected Entity ui;
        protected bool isStackable;
        protected bool isTimed;
        protected float duration;
        protected int maxStack = 1;
        protected int stackCount = 1;

        public float StartTime { get; protected set; }
        public bool IsStackable => isStackable;
        public bool IsTimed => isTimed;
        public int StackCount => stackCount;

        public void SetTarget(Entity target) => this.target = target;
        public void SetUI(Entity ui) => this.ui = ui;
        public void Configure(bool stackable, bool timed, float duration, int maxStack)
        {
            this.isStackable = stackable;
            this.isTimed = timed;
            this.duration = duration;
            this.maxStack = maxStack;
        }

        public virtual void Apply()
        {
            if (isTimed) StartTime = Time.time;
            OnApply?.Invoke();
        }

        public virtual void Tick() { }

        public virtual void Discard() => OnDiscard?.Invoke();

        public bool IsExpired() => isTimed && (Time.time - StartTime) >= duration;

        public void AddStack()
        {
            if (stackCount >= maxStack) return;
            stackCount++;
            OnStackAdded();
        }

        public void RefreshTimer()
        {
            if (isTimed) StartTime = Time.time;
        }

        protected virtual void OnStackAdded() => OnStack?.Invoke(stackCount);
    }
}