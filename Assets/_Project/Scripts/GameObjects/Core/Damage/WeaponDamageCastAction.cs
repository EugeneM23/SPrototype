using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponDamageCastAction : ITickable, WeaponShootComponent.IAction
    {
        private readonly DamageCasterManager _damageCasterManager;
        private readonly DamageCastLayer _damageCastLayer;

        [Inject(Id = ComponentsID.WeaponDamageRoot)]
        private Transform _damageRoot;

        [Inject(Id = WeaponParameterID.Damage)]
        private int _damage;

        [Inject(Id = WeaponParameterID.DamageCastDelay)]
        private float _damageCastDelay;

        private bool _enable;
        private float _timer;

        public WeaponDamageCastAction(DamageCasterManager damageCasterManager, DamageCastLayer damageCastLayer)
        {
            _damageCasterManager = damageCasterManager;
            _damageCastLayer = damageCastLayer;
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
            DamageCastParams damageCast = new DamageCastParams(_damage, 1, 1, _damageCastLayer, _damageRoot);
            _damageCasterManager.CastDamage(damageCast);
        }

        public void Invoke()
        {
            _enable = true;
            _timer = _damageCastDelay;
        }
    }
}