using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponShellSpawnComponent : WeaponShootComponent.IAction
    {
        [Inject(Id = WeaponParameterID.ShellImpulse)]
        private float _shellImpulse;

        private readonly Transform _shellPoint;
        private IShellSpawner _shellSpawner;

        public WeaponShellSpawnComponent(Transform shellPoint, IShellSpawner shellSpawner)
        {
            _shellPoint = shellPoint;
            _shellSpawner = shellSpawner;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            _shellSpawner.Create(_shellPoint.position, Quaternion.identity,
                _shellImpulse * _shellPoint.right, 1);
        }
    }
}