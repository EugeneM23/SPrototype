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
}