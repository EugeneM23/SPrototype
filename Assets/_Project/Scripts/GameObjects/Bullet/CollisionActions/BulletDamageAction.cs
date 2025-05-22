using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletDamageEntiyCollisionAction : BulletHitComponent.IEntiyCollisionAction
    {
        [Inject(Id = WeaponParameterID.Damage)]
        private int _damage;

        public void Invoke(IEntity entity)
        {
            if (entity.TryGet(out IDamageable damageable))
                damageable.TakeDamage(_damage);
        }
    }
}