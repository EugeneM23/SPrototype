using UnityEngine;

namespace Gameplay
{
    public class BulletPushEntiyCollisionAction : CollisionComponent.IEntiyCollisionAction
    {
        private readonly Entity _bullet;
        private readonly float _impulsePower = 50;
        private float _impulseTime = 0.2f;

        public BulletPushEntiyCollisionAction(Entity bullet)
        {
            _bullet = bullet;
        }

        public void Invoke(IEntity entity)
        {
            if (entity.TryGet<PushableObjectController>(out PushableObjectController pushableObject))
            {
                pushableObject.SetImpulse(_bullet.gameObject.transform.forward, _impulsePower, _impulseTime);
            }
        }
    }
}