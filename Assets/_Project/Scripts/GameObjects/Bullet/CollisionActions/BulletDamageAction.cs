using UnityEngine;

namespace Gameplay
{
    public class BulletDamageAction : BulletHitComponent.IEntiyCollisionAction
    {
        private int _damage;
        private bool _isSplashDamage;

        public void SetDamage(int damage) => _damage = damage;

        public void Invoke(RaycastHit collider)
        {
            if (collider.transform.GetComponent<Entity>().TryGet(out IDamageable damageable))
                damageable.TakeDamage(_damage);
        }
    }
}