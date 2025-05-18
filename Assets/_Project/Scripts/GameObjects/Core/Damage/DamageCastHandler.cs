using Gameplay.Installers;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class DamageCastHandler
    {
        private readonly DamageCasterManager _damageCasterManager;
        private readonly DamageCastLayer _damageCastLayer;

        [Inject(Id = ComponentsID.WeaponDamageRoot)]
        private Transform _damageRoot;

        private int _damage;

        public DamageCastHandler(DamageCasterManager damageCasterManager, DamageCastLayer damageCastLayer, int damage)
        {
            _damageCasterManager = damageCasterManager;
            _damageCastLayer = damageCastLayer;
            _damage = damage;
        }

        public void EnebleDamageCast()
        {
            DamageCastParams damageCast = new DamageCastParams(_damage, 1, 1, _damageCastLayer, _damageRoot);
            _damageCasterManager.CastDamage(damageCast);
        }
    }
}