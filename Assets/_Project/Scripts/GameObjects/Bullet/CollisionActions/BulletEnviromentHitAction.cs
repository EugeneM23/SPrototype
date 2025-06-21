using UnityEngine;

namespace Gameplay
{
    public class BulletEnviromentHitAction : BulletHitComponent.IEnviromentCollisionAction, BulletSplashHitComponent.ISplash
    {
        private readonly Entity _effect;
        private readonly GameFactory _factory;

        public BulletEnviromentHitAction(Entity effect, GameFactory factory)
        {
            _effect = effect;
            _factory = factory;
        }

        public void Invoke(RaycastHit hit)
        {
            Debug.Log("asdadas");
            if (_effect == null) return;

            Quaternion rotation = Quaternion.LookRotation(hit.normal);
            rotation.eulerAngles += new Vector3(90, 0, 0);
            Entity effect = _factory.Create(_effect);
            effect.transform.SetPositionAndRotation(hit.point, rotation);
        }
    }

    public class BulletEntityHitAction : BulletHitComponent.IEntiyCollisionAction
    {
        private readonly Entity _effect;
        private readonly GameFactory _factory;

        public BulletEntityHitAction(Entity effect, GameFactory factory)
        {
            _effect = effect;
            _factory = factory;
        }

        public void Invoke(RaycastHit collider)
        {
            if (_effect == null) return;

            Entity effect = _factory.Create(_effect);
            effect.transform.SetPositionAndRotation(collider.transform.position, collider.transform.rotation);
        }
    }
}