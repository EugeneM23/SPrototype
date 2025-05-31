using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BuffRage : IBuff
    {
        private Entity target;

        private Entity ui;
        private float speedPerStack;
        private float fireRatePerStack;
        private RageUI rageUI;
        private bool isStackable;
        private bool isTimed;
        private float duration;
        private int maxStack = 1;
        private int stackCount = 1;

        public float StartTime { get; private set; }
        public bool IsStackable => isStackable;
        public bool IsTimed => isTimed;

        public void SetTarget(Entity target) => this.target = target;
        public void SetUI(Entity ui) => this.ui = ui;

        public void Configure(bool stackable, bool timed, float duration, int maxStack)
        {
            this.isStackable = stackable;
            this.isTimed = timed;
            this.duration = duration;
            this.maxStack = maxStack;
        }

        public void Apply()
        {
            if (isTimed)
                StartTime = Time.time;
            target.Get<IMove>().AddSpeed(speedPerStack);
            target.Get<CharacterStats>().FireRateMultupleyer -= fireRatePerStack;

            rageUI = target.Get<GameFactory>().Create(ui).GetComponent<RageUI>();
        }

        public void Tick()
        {
            if (rageUI == null) return;

            float remainingTime = duration - (Time.time - StartTime);
            rageUI.UpdateSlider(remainingTime, duration);
        }

        public void Discard()
        {
            target.Get<IMove>().AddSpeed(-speedPerStack * stackCount);
            rageUI.GetComponent<Entity>().Dispose();
            target.Get<CharacterStats>().FireRateMultupleyer += fireRatePerStack * stackCount;
        }

        public bool IsExpired()
        {
            return isTimed && (Time.time - StartTime) >= duration;
        }

        public void AddStack()
        {
            if (stackCount >= maxStack) return;
            stackCount++;
            target.Get<IMove>().AddSpeed(speedPerStack);
            target.Get<CharacterStats>().FireRateMultupleyer -= fireRatePerStack;

            rageUI.UpdateStack(stackCount);
        }

        public void RefreshTimer()
        {
            if (isTimed) StartTime = Time.time;
        }

        public static Builder Create() => new Builder();

        public class Builder
        {
            private Entity target;
            private float speedPerStack;
            private float fireRatePerStack;
            private Entity ui;
            private bool stackable = false, timed = false;
            private int maxStack = 1;
            private float duration = 0;

            public Builder Target(Entity target)
            {
                this.target = target;
                return this;
            }

            public Builder SetStats(float speed, float fireRate)
            {
                fireRatePerStack = fireRate;
                speedPerStack = speed;
                return this;
            }

            public Builder UI(Entity ui)
            {
                this.ui = ui;
                return this;
            }

            public Builder Stackable(int max = 5)
            {
                stackable = true;
                maxStack = max;
                return this;
            }

            public Builder Timed(float time)
            {
                timed = true;
                duration = time;
                return this;
            }

            public BuffRage Build()
            {
                var buff = new BuffRage();
                buff.SetTarget(target);
                buff.speedPerStack = speedPerStack;
                buff.fireRatePerStack = fireRatePerStack;
                buff.SetUI(ui);
                buff.Configure(stackable, timed, duration, maxStack);
                return buff;
            }
        }
    }
}