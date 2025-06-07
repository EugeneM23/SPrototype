using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponDamageCastAction : ITickable, WeaponShootComponent.IAction
    {
        private readonly DamageCasterManager _damageCasterManager;
        private readonly DamageLayerComponent _damageCastLayer;

        private Transform _damageRoot;

        private readonly WeaponConfig _config;

        private readonly CharacterStats _stats;
        private bool _enable;
        private float _timer;

        public WeaponDamageCastAction(DamageCasterManager damageCasterManager, DamageLayerComponent damageCastLayer,
            CharacterStats stats, WeaponConfig config,
            [Inject(Id = DamageRootID.WeaponDamageRoot)]
            Transform damageRoot)
        {
            _damageCasterManager = damageCasterManager;
            _damageCastLayer = damageCastLayer;
            _stats = stats;
            _config = config;
            _damageRoot = damageRoot;

            Debug.Log(_damageCastLayer.GetDamageLayer());
        }

        public void Tick()
        {
            if (_enable)
            {
                EnableDamageCast();
                _enable = false;
            }
        }

        public void EnableDamageCast()
        {
            float timeCast = _config.fireRate * (1 - _stats.FireRateMultiplier / 100f);
            DamageCastParams damageCast =
                new DamageCastParams(_config.damage, 3, timeCast / 2, _damageCastLayer.GetDamageLayer(), _damageRoot);
            _damageCasterManager.CastDamage(damageCast);
        }

        public void Invoke()
        {
            _enable = true;
            _timer = _config.fireRate;
        }
    }
}