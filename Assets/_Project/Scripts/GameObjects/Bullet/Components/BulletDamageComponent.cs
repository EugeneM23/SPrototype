using Zenject;

namespace Gameplay
{
    public class BulletDamageComponent : Bullet.IAction
    {
        [Inject(Id = WeaponParameterID.Damage)]
        private int _damage;

        public void Invoke(IEntity entity)
        {
            if (entity.TryGet(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
            }
        }
    }
}