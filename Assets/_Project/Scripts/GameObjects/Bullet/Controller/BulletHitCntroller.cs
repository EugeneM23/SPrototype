using System;
using Zenject;

namespace Gameplay
{
    public class BulletHitCntroller
    {
        private readonly BulletCollisionComponent _collisionComponent;
        private readonly BulletHitComponent _bulletHitComponent;

        public BulletHitCntroller(BulletCollisionComponent collisionComponent, BulletHitComponent bulletHitComponent)
        {
            _collisionComponent = collisionComponent;
            _bulletHitComponent = bulletHitComponent;
        }
    }
}