using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponClipComponent
    {
        public event Action<int> OnCurrentCapacityChanget;
        public int CLipCapacity { get; private set; }
        public int CurrentCapacity { get; private set; }

        private readonly Inventory _inventory;

        public WeaponClipComponent([Inject(Id = WeaponParameterID.ClipCapacity)] int cLipCapacity,
            [Inject(Id = WeaponParameterID.BulletCount)]
            int bulletCount, Inventory inventory)
        {
            CLipCapacity = cLipCapacity;
            _inventory = inventory;
            CurrentCapacity = CLipCapacity;
        }

        public void Count()
        {
            if (CurrentCapacity > 0)
            {
                CurrentCapacity--;
                OnCurrentCapacityChanget?.Invoke(CurrentCapacity);
            }
        }

        public void Reload()
        {
            if (_inventory.BulletCount >= CLipCapacity)
                _inventory.BulletCount -= CLipCapacity;
            else
            {
                CurrentCapacity = _inventory.BulletCount;
                _inventory.BulletCount = 0;
                OnCurrentCapacityChanget?.Invoke(CurrentCapacity);
                return;
            }

            CurrentCapacity = CLipCapacity;

            OnCurrentCapacityChanget?.Invoke(CurrentCapacity);
        }
    }
}