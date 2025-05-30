using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponBulletSpawnAction : WeaponShootComponent.IAction, ITickable
    {
        [Inject(Id = WeaponParameterID.Scatter)]
        private float _scater;

        [Inject(Id = WeaponParameterID.ProjectileCount)]
        private int _projectileCount;

        [Inject(Id = WeaponParameterID.ProjectileSpawnDelay)]
        private float _delay;

        [Inject(Id = WeaponParameterID.BulletSpeed)]
        private float _bulletSpeed;

        [Inject(Id = WeaponParameterID.Damage)]
        private int _bulletDamage;

        private readonly GameFactory _factory;
        private readonly Entity _bulletPrefab;

        private readonly Entity _character;
        private readonly TargetComponent _targetComponent;
        private readonly Transform _firePoint;
        private float _timer;
        private bool _needSpawn;

        public WeaponBulletSpawnAction(
            TargetComponent targetComponent,
            Transform firePoint,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity character,
            GameFactory factory,
            [Inject(Id = WeaponParameterID.BulletPrefab)]
            Entity bulletPrefab
        )
        {
            _targetComponent = targetComponent;
            _firePoint = firePoint;
            _character = character;
            _factory = factory;
            _bulletPrefab = bulletPrefab;
        }

        public void Tick()
        {
            if (!_needSpawn) return;

            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                for (int i = 0; i < _projectileCount; i++)
                {
                    Quaternion rotation = CalculatRotation();
                    Entity bullet = _factory.Create(_bulletPrefab, 10);
                    bullet.gameObject.transform.position = _firePoint.position;
                    bullet.gameObject.transform.rotation = rotation;
                    bullet.Get<BulletMoveComponent>().SetSeed(_bulletSpeed);
                    bullet.Get<BulletDamageAction>().SetDamage(_bulletDamage);
                }

                _needSpawn = false;
            }
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            _needSpawn = true;
            _timer = _delay;
        }

        private Quaternion CalculatRotation()
        {
            if (_targetComponent.Target == null) return Quaternion.identity;

            Vector3 targetPosition = _targetComponent.Target.position + Vector3.up * 1.5f;

            Vector3 directionToTarget = (targetPosition - _character.transform.position).normalized;
            //Vector3 directionToTarget =  _firePoint.forward.normalized;

            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            float randomY = Random.Range(-_scater, _scater);
            float randomX = Random.Range(-_scater, _scater);
            Quaternion scatterRotation = Quaternion.Euler(randomX, randomY, 0f);
            Quaternion finalRotation = scatterRotation * lookRotation;
            return finalRotation;
        }
    }
}