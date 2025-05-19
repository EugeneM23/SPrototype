using System;
using Zenject;

namespace Gameplay
{
    public class BulletCollisionController : IInitializable, IDisposable
    {
        private readonly CollisionComponent _collisionComponent;
        private readonly Bullet _bullet;

        public BulletCollisionController(CollisionComponent collisionComponent, Bullet bullet)
        {
            _collisionComponent = collisionComponent;
            _bullet = bullet;
        }

        public void Initialize()
        {
            _collisionComponent.OnCollision += _bullet.Hit;
        }

        public void Dispose()
        {
            //_collisionComponent.OnCollision -= _bullet.Hit;
        }
    }
}