using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public abstract class BaseBuff : IBuff
    {
        protected Entity target;
        protected Entity ui;

        protected bool isStackable;
        protected bool isTimed;
        protected float duration;
        protected int maxStack = 1;
        protected int stackCount = 1;
        protected float startTime;

        protected Dictionary<BuffMultiplayerID, float> statValues = new();

        public bool IsStackable => isStackable;
        public bool IsTimed => isTimed;
        public float StartTime => startTime;

        public virtual void Configure(BuffConfig config)
        {
            target = config.Target;
            ui = config.UI;
            isStackable = config.IsStackable;
            maxStack = config.MaxStack;
            isTimed = config.IsTimed;
            duration = config.Duration;

            if (config.Stats != null)
                foreach (var stat in config.Stats)
                    statValues[stat.Key] = stat.Value;
        }

        public virtual void Apply()
        {
            if (isTimed)
                startTime = Time.time;

            if (target != null)
            {
                ApplyEffects();
            }

            CreateUI();
        }

        public virtual void Tick()
        {
            UpdateUI();
        }

        public virtual void Discard()
        {
            RemoveEffects();
            DestroyUI();
        }

        public virtual bool IsExpired()
        {
            return isTimed && (Time.time - startTime) >= duration;
        }

        public virtual void AddStack()
        {
            if (stackCount >= maxStack) return;

            stackCount++;
            ApplyStackEffect();
            UpdateStackUI();
        }

        public virtual void RefreshTimer()
        {
            if (isTimed)
                startTime = Time.time;
        }

        protected abstract void ApplyEffects();
        protected abstract void RemoveEffects();
        protected abstract void ApplyStackEffect();

        protected virtual void CreateUI()
        {
        }

        protected virtual void UpdateUI()
        {
        }

        protected virtual void UpdateStackUI()
        {
        }

        protected virtual void DestroyUI()
        {
        }
    }
}