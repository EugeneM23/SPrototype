using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletMoveComponent : IBulletMoveComponent
    {
        [Inject(Id = WeaponParameterID.BulletSpeed)]
        private float _bulletSpeed;

        private readonly Entity _bullet;
        private Vector3 _direction;

        public BulletMoveComponent(Entity bullet)
        {
            _bullet = bullet;
        }

        public void Move()
        {
            _bullet.transform.position += _bullet.transform.forward * Time.deltaTime * _bulletSpeed;
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