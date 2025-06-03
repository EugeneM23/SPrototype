using Gameplay.Installers;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

namespace Gameplay
{
    public class WeaponDamageCastAction : ITickable, WeaponShootComponent.IAction
    {
        private readonly DamageCasterManager _damageCasterManager;
        private readonly DamageCastLayer _damageCastLayer;

        [Inject(Id = DamageRootID.WeaponDamageRoot)]
        private Transform _damageRoot;

        [Inject(Id = WeaponParameterID.Damage)]
        private int _damage;

        [Inject(Id = WeaponParameterID.DamageCastDelay)]
        private float _damageCastDelay;

        [Inject(Id = WeaponParameterID.FireRate)]
        private float _fireRate;

        private readonly CharacterStats _stats;
        private bool _enable;
        private float _timer;

        public WeaponDamageCastAction(DamageCasterManager damageCasterManager, DamageCastLayer damageCastLayer,
            CharacterStats stats)
        {
            _damageCasterManager = damageCasterManager;
            _damageCastLayer = damageCastLayer;
            _stats = stats;
        }

        public void Tick()
        {
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
            float timeCast = _fireRate * (1 - _stats.FireRateMultupleyer / 100f);
            DamageCastParams damageCast = new DamageCastParams(_damage, 1, timeCast, _damageCastLayer, _damageRoot);
            _damageCasterManager.CastDamage(damageCast);
        }

        public void Invoke()
        {
            _enable = true;
            _timer = _damageCastDelay;
        }
    }
}