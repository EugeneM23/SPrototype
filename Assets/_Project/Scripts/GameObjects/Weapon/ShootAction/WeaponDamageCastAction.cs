using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponDamageCastAction : ITickable, WeaponShootComponent.IAction
    {
        private readonly DamageCasterManager _damageCasterManager;
        private readonly DamageCastLayer _damageCastLayer;

        [Inject(Id = DamageRootID.WeaponDamageRoot)]
        private Transform _damageRoot;

        private readonly MeleeWeaponConfig _config;

        private readonly CharacterStats _stats;
        private bool _enable;
        private float _timer;

        public WeaponDamageCastAction(DamageCasterManager damageCasterManager, DamageCastLayer damageCastLayer,
            CharacterStats stats, MeleeWeaponConfig config)
        {
            _damageCasterManager = damageCasterManager;
            _damageCastLayer = damageCastLayer;
            _stats = stats;
            _config = config;
        }

        public void Tick()
        {
            Debug.Log("Damaged");
            if (_enable)
            {
                _timer -= Time.deltaTime;
                if (_timer <= 0)
                {
                    EnableDamageCast();
                    _enable = false;
                }
            }
        }

        public void EnableDamageCast()
        {
            float timeCast = _config.fireRate * (1 - _stats.FireRateMultupleyer / 100f);
            DamageCastParams damageCast =
                new DamageCastParams(_config.damage, 1, timeCast, _damageCastLayer, _damageRoot);
            _damageCasterManager.CastDamage(damageCast);
        }

        public void Invoke()
        {
            _enable = true;
            _timer = _config.damageCastDelay;
        }
    }
}