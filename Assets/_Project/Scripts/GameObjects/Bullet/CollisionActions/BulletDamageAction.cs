namespace Gameplay
{
    public class BulletDamageAction : BulletHitComponent.IEntiyCollisionAction
    {
        private int _damage;

        public void Invoke(IEntity entity)
        {
            if (entity.TryGet(out IDamageable damageable))
                damageable.TakeDamage(_damage);
        }

        public void SetDamage(int damage) => _damage = damage;
    }
}