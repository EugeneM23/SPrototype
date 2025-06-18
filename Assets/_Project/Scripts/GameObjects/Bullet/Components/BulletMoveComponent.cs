using UnityEngine;

namespace Gameplay
{
    public class BulletMoveComponent : IBulletMoveComponent
    {
        private float _bulletSpeed;

        private readonly Entity _bullet;

        public BulletMoveComponent(Entity bullet)
        {
            _bullet = bullet;
        }

        public void Move()
        {
            _bullet.transform.position += _bullet.transform.forward * Time.deltaTime * _bulletSpeed;
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            _bullet.transform.position = position;
            _bullet.transform.rotation = rotation;
        }

        public void SetSeed(int seed) => _bulletSpeed = seed;
    }
}