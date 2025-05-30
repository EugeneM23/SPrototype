using UnityEngine;

namespace Gameplay
{
    public class BulletEnviromentHitAction : BulletHitComponent.IEnviromentCollisionAction
    {
        private readonly Entity _effect;
        private readonly GameFactory _factory;

        public BulletEnviromentHitAction(Entity effect, GameFactory factory)
        {
            _effect = effect;
            _factory = factory;
        }

        public void Invoke(Collision collision)
        {
            ContactPoint point = collision.contacts[0];
            Quaternion rotation = Quaternion.LookRotation(point.normal);
            var effect = _factory.Create(_effect);
            effect.transform.position = point.point;
            effect.transform.rotation = rotation;
        }
    }
}