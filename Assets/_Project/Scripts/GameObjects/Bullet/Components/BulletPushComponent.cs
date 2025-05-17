namespace Gameplay
{
    public class BulletPushComponent : Bullet.IAction
    {
        private readonly Entity _bullet;
        private readonly float _impulsePower = 50;
        private float _impulseTime = 0.2f;

        public BulletPushComponent(Entity bullet)
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