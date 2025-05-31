using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BuffRage : BuffBase, ITickable
{
    private readonly float speedPerStack;
    private float _timer;

    private BuffRage(Entity target, Entity rageUi, float speedPerStack,
        bool isStackable, bool isTimed, float duration, int maxStack)
        : base(target, rageUi, isStackable, isTimed, duration, maxStack)
    {
        this.speedPerStack = speedPerStack;
    }

    public override void Apply()
    {
        base.Apply();
        target.Get<IMove>().AddSpeed(speedPerStack);
    }

    public override void Tick()
    {
        Debug.Log(Time.time - StartTime);
    }

    public override void Discard()
    {
        target.Get<IMove>().AddSpeed(speedPerStack * stackCount * -1);
    }

    protected override void OnStackAdded()
    {
        base.OnStackAdded();
        target.Get<IMove>().AddSpeed(speedPerStack);
    }

    public class Prototype
    {
        private Entity target;
        private Entity rageUi;
        private float speedPerStack;
        private bool isStackable = false;
        private bool isTimed = false;
        private float duration = 0f;
        private int maxStack = 1;

        public Prototype SetTarget(Entity target)
        {
            this.target = target;
            return this;
        }

        public Prototype SetUI(Entity rageUi)
        {
            this.rageUi = rageUi;
            return this;
        }

        public Prototype SetSpeedPerStack(float value)
        {
            this.speedPerStack = value;
            return this;
        }

        public Prototype SetTimed(float duration)
        {
            this.isTimed = true;
            this.duration = duration;
            return this;
        }

        public Prototype SetStackable(int maxStack)
        {
            this.isStackable = true;
            this.maxStack = maxStack;
            return this;
        }

        public BuffRage Build()
        {
            if (target == null || rageUi == null)
                throw new InvalidOperationException("Target and RageUI must be set.");

            return new BuffRage(target, rageUi, speedPerStack, isStackable, isTimed, duration, maxStack);
        }
    }
}

}