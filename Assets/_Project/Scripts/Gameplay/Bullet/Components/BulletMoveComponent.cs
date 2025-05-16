using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletMoveComponent : IBulletMoveComponent
    {
        private readonly Entity _bullet;
        private readonly WeaponSetings _setings;
        private Vector3 _direction;

        public BulletMoveComponent(Entity bullet, WeaponSetings setings)
        {
            _bullet = bullet;
            _setings = setings;
        }

        public void Move()
        {
            _bullet.transform.position += _bullet.transform.forward * Time.deltaTime * _setings.BulletSpeed;
        }
    }

    public interface IBulletMoveComponent
    {
        void Move();
    }

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