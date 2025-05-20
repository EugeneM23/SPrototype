using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletDamageEntiyCollisionAction : CollisionComponent.IEntiyCollisionAction
    {
        [Inject(Id = WeaponParameterID.Damage)]
        private int _damage;

        public void Invoke(IEntity entity)
        {
            if (entity.TryGet(out ITakedamageComponent damageable))
                damageable.TakeDamage(_damage);
        }
    }
}