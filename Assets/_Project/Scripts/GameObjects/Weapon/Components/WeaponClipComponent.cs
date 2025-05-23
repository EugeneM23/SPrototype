using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponClipComponent
    {
        public event Action<int> OnCurrentCapacityChanget;
        public event Action<int> OnBulletCountChanget;
        public int BulletCount { get; private set; }
        public int CLipCapacity { get; private set; }
        public int CurrentCapacity { get; private set; }

        public WeaponClipComponent([Inject(Id = WeaponParameterID.ClipCapacity)] int cLipCapacity)
        {
            CLipCapacity = cLipCapacity;
            CurrentCapacity = CLipCapacity;
        }

        public void Count()
        {
            Debug.Log(CurrentCapacity);
            if (CurrentCapacity > 0)
            {
                CurrentCapacity--;
                OnCurrentCapacityChanget?.Invoke(CurrentCapacity);
            }
        }

        public void Reload()
        {
            if (BulletCount >= CLipCapacity)
                BulletCount -= CLipCapacity;
            else
            {
                CurrentCapacity = BulletCount;
                BulletCount = 0;
                OnCurrentCapacityChanget?.Invoke(CurrentCapacity);
                OnBulletCountChanget?.Invoke(BulletCount);
                return;
            }

            CurrentCapacity = CLipCapacity;

            OnCurrentCapacityChanget?.Invoke(CurrentCapacity);
            OnBulletCountChanget?.Invoke(BulletCount);
        }
    }
}