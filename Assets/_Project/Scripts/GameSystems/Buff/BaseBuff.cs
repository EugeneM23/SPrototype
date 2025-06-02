using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class BaseBuff : IBuff
    {
        private Entity target;

        private bool isStackable;
        private bool isTimed;
        private float duration;
        private int maxStack = 1;
        private int stackCount = 1;
        private float startTime;

        private float speedPerStack;
        private float fireRatePerStack;

        private Dictionary<BuffMultiplayerID, float> statValues = new();
        private float _timer;

        public bool IsStackable => isStackable;
        public bool IsTimed => isTimed;

        private CharacterStats _stats;

        public void Configure(BuffConfig config)
        {
            target = config.Target;
            isStackable = config.IsStackable;
            maxStack = config.MaxStack;
            isTimed = config.IsTimed;
            duration = config.Duration;

            if (config.Stats != null)
            {
                foreach (var stat in config.Stats)
                    statValues[stat.Key] = stat.Value;
            }

            speedPerStack = statValues[BuffMultiplayerID.Speed];
            fireRatePerStack = statValues[BuffMultiplayerID.FireRate];

            _stats = target.Get<CharacterStats>();
        }

        public void Apply()
        {
            if (isTimed)
                startTime = Time.time;

            _stats.RunSpeedMultiplayer += speedPerStack;
            _stats.FireRateMultupleyer += fireRatePerStack;
        }

        public void Discard()
        {
            _stats.RunSpeedMultiplayer -= speedPerStack * stackCount;
            _stats.FireRateMultupleyer -= fireRatePerStack * stackCount;
        }

        public void AddStack()
        {
            if (stackCount >= maxStack) return;

            stackCount++;
            _stats.RunSpeedMultiplayer += speedPerStack;
            _stats.FireRateMultupleyer += fireRatePerStack;
        }

        public void Tick()
        {
        }

        public bool IsExpired() => isTimed && (Time.time - startTime) >= duration;

        public void RefreshTimer()
        {
            if (isTimed)
                startTime = Time.time;
        }
    }
}