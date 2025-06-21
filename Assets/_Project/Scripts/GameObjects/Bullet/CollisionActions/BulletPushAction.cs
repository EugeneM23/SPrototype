using UnityEngine;

namespace Gameplay
{
    public class BulletPushEntiyCollisionAction : BulletHitComponent.IEntiyCollisionAction
    {
        private readonly Entity _bullet;
        private readonly float _impulsePower = 50;
        private float _impulseTime = 0.2f;

        public BulletPushEntiyCollisionAction(Entity bullet)
        {
            _bullet = bullet;
        }

        public void Invoke(RaycastHit collider)
        {
            if (collider.transform.GetComponent<Entity>().TryGet(out PushableObjectController pushableObject))
            {
                pushableObject.SetImpulse(_bullet.gameObject.transform.forward, _impulsePower, _impulseTime);
            }
        }
    }
}