using System;
using Zenject;

namespace Gameplay
{
    public class BulletHitCntroller : IInitializable, IDisposable
    {
        private readonly CollisionComponent _collisionComponent;
        BulletHitComponent _bulletHitComponent;

        public BulletHitCntroller(CollisionComponent collisionComponent, BulletHitComponent bulletHitComponent)
        {
            _collisionComponent = collisionComponent;
            _bulletHitComponent = bulletHitComponent;
        }

        public void Initialize() => _collisionComponent.OnHit += _bulletHitComponent.OnHit;

        public void Dispose() => _collisionComponent.OnHit -= _bulletHitComponent.OnHit;
    }
}