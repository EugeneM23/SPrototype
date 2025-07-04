using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class BaseBuff : IBuff
    {
        public event Action<int> OnStack;
        public event Action OnApply;
        public event Action OnDiscard; // Исправлена опечатка в названии
        public event Action<float> OnTick;

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

        public int StackCount => stackCount;

        public bool IsStackable => isStackable;
        public bool IsTimed => isTimed;

        private CharacterStats _stats;
        private Action _stackAction;
        private Action _applyAction;

        public void Configure(BuffConfig config)
        {
            target = config.Target;
            isStackable = config.IsStackable;
            maxStack = config.MaxStack;
            isTimed = config.IsTimed;
            duration = config.Duration;
            _stackAction = config.StackAction;
            _applyAction = config.ApplyAction;

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
            _stackAction?.Invoke();
            _applyAction?.Invoke();
            OnApply?.Invoke();
            if (isTimed)
                startTime = Time.time;

            _stats.RunSpeedMultiplier += speedPerStack;
            _stats.FireRateMultiplier += fireRatePerStack;
        }

        public void Discard()
        {
            OnDiscard?.Invoke();
            // ИСПРАВЛЕНИЕ: вычитаем только количество стеков, которое было добавлено
            _stats.RunSpeedMultiplier -= speedPerStack * stackCount;
            _stats.FireRateMultiplier -= fireRatePerStack * stackCount;
        }

        public void AddStack()
        {
            if (stackCount >= maxStack) return; // Проверка перенесена в начало

            stackCount++;
            _applyAction?.Invoke();
            OnStack?.Invoke(stackCount);
            _stats.RunSpeedMultiplier += speedPerStack;
            _stats.FireRateMultiplier += fireRatePerStack;
        }

        public void Tick()
        {
            OnTick?.Invoke(Time.time - startTime);
        }

        public bool IsExpired() => isTimed && (Time.time - startTime) >= duration;

        public void RefreshTimer()
        {
            if (isTimed)
                startTime = Time.time;
        }
    }
}