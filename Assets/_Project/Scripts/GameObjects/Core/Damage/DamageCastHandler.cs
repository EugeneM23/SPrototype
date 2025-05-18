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

        [Inject(Id = WeaponParameterID.Damage)]
        private int _damage;

        public DamageCastHandler(DamageCasterManager damageCasterManager, DamageCastLayer damageCastLayer)
        {
            _damageCasterManager = damageCasterManager;
            Debug.Log("asdas");
            _damageCastLayer = damageCastLayer;
        }

        public void EnebleDamageCast()
        {
            DamageCastParams damageCast = new DamageCastParams(_damage, 1, 1, _damageCastLayer, _damageRoot);
            _damageCasterManager.CastDamage(damageCast);
        }
    }
}