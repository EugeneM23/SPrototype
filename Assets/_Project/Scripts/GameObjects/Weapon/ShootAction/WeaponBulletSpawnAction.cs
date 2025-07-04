using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponBulletSpawnAction : WeaponShootComponent.IAction, ITickable
    {
        private readonly RangedWeaponConfig _config;
        private readonly DamageLayerComponent _damageLayer;
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
            Entity bulletPrefab,
            RangedWeaponConfig config, DamageLayerComponent damageLayer)
        {
            _targetComponent = targetComponent;
            _firePoint = firePoint;
            _character = character;
            _factory = factory;
            _bulletPrefab = bulletPrefab;
            _config = config;
            _damageLayer = damageLayer;
        }

        public void Tick()
        {
            if (!_needSpawn) return;

            for (int i = 0; i < _config.projectileCount; i++)
            {
                Quaternion rotation = CalculatRotation();
                Entity bullet = _factory.Create(_bulletPrefab, 10);
                bullet.Get<BulletCollisionComponent>().ResetRaycastPosition(_firePoint.position);
                bullet.Get<IBulletMoveComponent>().SetPositionAndRotation(_firePoint.position, rotation);
                bullet.Get<BulletCollisionComponent>().SetCollisionLayer(_damageLayer.LayerMask);
                bullet.Get<IBulletMoveComponent>().SetSeed(_config.bulletSpeed);
                bullet.Get<BulletDamageAction>().SetDamage(_config.damage);

                if (bullet.TryGet<BulletProjectileMoveComponent>(out var component))
                    component.SetTargetPos(_character.Get<TargetComponent>().Target.position);
            }

            _needSpawn = false;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            _needSpawn = true;
        }

        private Quaternion CalculatRotation()
        {
            Vector3 targetPosition = _targetComponent.Target.position;

            Vector3 directionToTarget = (targetPosition + Vector3.up * 1.5f - _firePoint.position).normalized;
            Debug.DrawRay(_firePoint.position, directionToTarget * 2000f, Color.red, 1f);

            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            float randomY = Random.Range(-_config.scatter, _config.scatter);
            Quaternion scatterRotation = Quaternion.Euler(0, randomY, 0f);
            Quaternion finalRotation = scatterRotation * lookRotation;


            return finalRotation;
        }
    }
}