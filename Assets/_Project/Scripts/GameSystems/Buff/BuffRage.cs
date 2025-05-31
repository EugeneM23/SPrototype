using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BuffRage : BuffBase, ITickable
    {
        private float speedPerStack;
        private RageUI rageUI;

        public override void Apply()
        {
            Debug.Log("BuffRage Apply");
            base.Apply();
            target.Get<IMove>().AddSpeed(speedPerStack);
            rageUI = target.Get<GameFactory>().Create(ui).GetComponent<RageUI>();
        }

        public override void Tick()
        {
            if (rageUI == null) return;

            float remainingTime = duration - (Time.time - StartTime);
            rageUI.UpdateSlider(remainingTime, duration);
        }

        public override void Discard()
        {
            base.Discard();
            target.Get<IMove>().AddSpeed(-speedPerStack * stackCount);
            rageUI.GetComponent<Entity>().Dispose();
        }

        protected override void OnStackAdded()
        {
            base.OnStackAdded();
            target.Get<IMove>().AddSpeed(speedPerStack);
            rageUI.UpdateStack(stackCount);
        }

        public static Builder Create() => new Builder();

        public class Builder
        {
            private Entity target;
            private float speedPerStack;
            private Entity ui;
            private bool stackable = false, timed = false;
            private int maxStack = 1;
            private float duration = 0;

            public Builder Target(Entity target)
            {
                this.target = target;
                return this;
            }

            public Builder Speed(float speed)
            {
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
                buff.SetUI(ui);
                buff.Configure(stackable, timed, duration, maxStack);
                return buff;
            }
        }
    }
}