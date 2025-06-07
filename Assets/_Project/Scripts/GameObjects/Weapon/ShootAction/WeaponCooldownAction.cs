using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponCooldownAction : WeaponShootComponent.ICondition, WeaponShootComponent.IAction, ITickable
    {
        private readonly WeaponConfig _config;

        [Inject] private readonly CharacterStats _stats;

        private float lastTimeShoot;

        public WeaponCooldownAction(WeaponConfig config)
        {
            _config = config;
        }

        bool WeaponShootComponent.ICondition.Invoke()
        {
            return lastTimeShoot <= 0;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            lastTimeShoot = GetFireRate();
        }

        private float GetFireRate()
        {
            return Mathf.Max(_config.fireRate * (1 - _stats.FireRateMultiplier / 100f), 0);
        }

        public void Tick()
        {
            lastTimeShoot -= Time.deltaTime;
        }
    }
}