using System;
using System.Data;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponClipComponent : IInitializable
    {
        public event Action<int> OnCurrentCapacityChanget;
        public int MaxCapacity;

        private int _currentCapacity;

        public int CurrentCapacity
        {
            get { return _currentCapacity; }
            set
            {
                if (value > MaxCapacity)
                    throw new InvalidExpressionException();

                _currentCapacity = value;
            }
        }

        public WeaponClipComponent(int maxCapacity)
        {
            _currentCapacity = maxCapacity;
            MaxCapacity = maxCapacity;
        }

        public void Count()
        {
            if (CurrentCapacity > 0)
            {
                CurrentCapacity--;
                OnCurrentCapacityChanget?.Invoke(CurrentCapacity);
            }
        }

        public void Initialize() => _currentCapacity = MaxCapacity;
    }
}