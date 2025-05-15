using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BulletMoveComponent : ITickable
    {
        private readonly Transform _bulletTransform;
        private Vector3 _direction;
        private readonly WeaponSetings _setings;

        public BulletMoveComponent(Transform bulletTransform, WeaponSetings setings)
        {
            _bulletTransform = bulletTransform;
            _setings = setings;
        }


        public void Tick()
        {
            _bulletTransform.position += _bulletTransform.forward * Time.deltaTime * _setings.BulletSpeed;
        }
    }
}