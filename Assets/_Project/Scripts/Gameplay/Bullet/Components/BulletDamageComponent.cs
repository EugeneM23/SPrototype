using Modules;
using UnityEngine;

namespace Gameplay
{
    public class BulletDamageComponent : Bullet.IAction
    {
        private readonly WeaponSetings _setings;

        public BulletDamageComponent(WeaponSetings setings)
        {
            _setings = setings;
        }

        public void Invoke(IEntity entity)
        {
            if (entity.TryGet(out IDamageable damageable))
            {
                damageable.TakeDamage(_setings.Damage);
            }
        }
    }
}