using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletMoveController : ITickable
    {
        private readonly IBulletMoveComponent _bulletMoveComponent;

        public BulletMoveController(IBulletMoveComponent bulletMoveComponent)
        {
            _bulletMoveComponent = bulletMoveComponent;
        }

        public void Tick()
        {
            _bulletMoveComponent.Move();
        }
    }
}