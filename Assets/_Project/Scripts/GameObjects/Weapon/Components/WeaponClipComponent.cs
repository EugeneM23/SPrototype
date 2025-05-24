using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponClipComponent
    {
        public event Action<int> OnCurrentCapacityChanget;
        public event Action<int> OnBulletCountChanget;
        public int BulletCount => _backpack.BulletCount;
        public int CLipCapacity { get; private set; }
        public int CurrentCapacity { get; private set; }

        public BackPack _backpack;

        public WeaponClipComponent([Inject(Id = WeaponParameterID.ClipCapacity)] int cLipCapacity,
            [Inject(Id = WeaponParameterID.BulletCount)]
            int bulletCount)
        {
            CLipCapacity = cLipCapacity;
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
            Debug.Log(_backpack.BulletCount);
            if (_backpack.BulletCount >= CLipCapacity)
                _backpack.BulletCount -= CLipCapacity;
            else
            {
                CurrentCapacity = _backpack.BulletCount;
                _backpack.BulletCount = 0;
                OnCurrentCapacityChanget?.Invoke(CurrentCapacity);
                OnBulletCountChanget?.Invoke(BulletCount);
                return;
            }

            CurrentCapacity = CLipCapacity;

            OnCurrentCapacityChanget?.Invoke(CurrentCapacity);
            OnBulletCountChanget?.Invoke(_backpack.BulletCount);
        }
    }
}