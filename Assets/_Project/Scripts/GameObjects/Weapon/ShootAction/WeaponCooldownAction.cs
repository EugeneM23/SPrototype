using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponCooldownAction : WeaponShootComponent.ICondition, WeaponShootComponent.IAction, ITickable
    {
        [Inject(Id = WeaponParameterID.FireRate)]
        private float _fireRate;

        [Inject] private readonly CharacterStats _stats;

        private float lastTimeShoot;

        bool WeaponShootComponent.ICondition.Invoke()
        {
            return lastTimeShoot <= 0;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            lastTimeShoot = GetFireRate();

        }

        private float GetFireRate() => Mathf.Max(_fireRate * (1 - _stats.FireRateMultupleyer / 100f), 0);

        public void Tick()
        {
            lastTimeShoot -= Time.deltaTime;
            Debug.Log(lastTimeShoot < 0);
        }
    }
}