using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponCooldownAction : WeaponShootComponent.ICondition, WeaponShootComponent.IAction, ITickable
    {
        [Inject(Id = WeaponParameterID.FireRate)]
        private float _fireRate;

        private float lastTimeShoot;

        bool WeaponShootComponent.ICondition.Invoke()
        {
            return lastTimeShoot <= 0;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            lastTimeShoot = _fireRate;
        }

        public void Tick()
        {
            lastTimeShoot -= Time.deltaTime;
        }
    }
}