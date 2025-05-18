using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponBulletSpawnComponent : WeaponShootComponent.IAction
    {
        [Inject(Id = WeaponParameterID.Scatter)]
        private float _scater;

        private readonly WeaponTargetComponent _targetComponent;
        private readonly Transform _firePoint;
        private IBulletSpawner _bulletSpawner;

        public WeaponBulletSpawnComponent(WeaponTargetComponent targetComponent, Transform firePoint,
            IBulletSpawner bulletSpawner)
        {
            _targetComponent = targetComponent;
            _firePoint = firePoint;
            _bulletSpawner = bulletSpawner;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            Quaternion rotation = CalculatRotation();
            Entity bullet = _bulletSpawner.Create();
            bullet.gameObject.transform.position = _firePoint.position;
            bullet.gameObject.transform.rotation = rotation;
        }

        private Quaternion CalculatRotation()
        {
            if (_targetComponent.Target == null) return Quaternion.identity;

            Vector3 targetPosition = _targetComponent.Target.position + Vector3.up * 1.5f;

            Vector3 directionToTarget = (targetPosition - _firePoint.position).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            float randomY = Random.Range(-_scater, _scater);
            float randomX = Random.Range(-_scater, _scater);
            Quaternion scatterRotation = Quaternion.Euler(randomX, randomY, 0f);
            Quaternion finalRotation = scatterRotation * lookRotation;
            return finalRotation;
        }
    }

    public class WeaponTargetComponent
    {
        public Transform Target;
    }
}