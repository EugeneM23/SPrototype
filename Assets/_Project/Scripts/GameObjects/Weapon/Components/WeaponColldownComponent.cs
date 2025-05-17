using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponColldownComponent : WeaponShootComponent.ICondition, WeaponShootComponent.IAction, ITickable
    {
        private float lastTimeShoot;
        private WeaponSetings _setings;

        public WeaponColldownComponent(WeaponSetings setings)
        {
            _setings = setings;
        }

        bool WeaponShootComponent.ICondition.Invoke()
        {
            return lastTimeShoot <= 0;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            lastTimeShoot = _setings.FireRate;
        }

        public void Tick()
        {
            lastTimeShoot -= Time.deltaTime;
        }
    }
}