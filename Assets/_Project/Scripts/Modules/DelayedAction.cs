using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class DelayedAction : ITickable
    {
        private class ScheduledAction
        {
            public float Timer;
            public Action Action;

            public ScheduledAction(float delay, Action action)
            {
                Timer = delay;
                Action = action;
            }
        }

        private readonly List<ScheduledAction> _scheduledActions = new();

        public void Schedule(float delay, Action action)
        {
            _scheduledActions.Add(new ScheduledAction(delay, action));
        }

        public void Tick()
        {
            for (int i = _scheduledActions.Count - 1; i >= 0; i--)
            {
                var scheduled = _scheduledActions[i];
                scheduled.Timer -= Time.deltaTime;

                if (scheduled.Timer <= 0f)
                {
                    scheduled.Action?.Invoke();
                    _scheduledActions.RemoveAt(i);
                }
            }
        }
    }
}