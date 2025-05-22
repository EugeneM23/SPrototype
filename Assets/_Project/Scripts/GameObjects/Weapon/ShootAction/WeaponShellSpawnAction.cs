using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponShellSpawnAction : WeaponShootComponent.IAction
    {
        [Inject(Id = WeaponParameterID.ShellImpulse)]
        private float _shellImpulse;

        private readonly Transform _shellPoint;
        private IShellSpawner _shellSpawner;

        public WeaponShellSpawnAction(Transform shellPoint, IShellSpawner shellSpawner)
        {
            _shellPoint = shellPoint;
            _shellSpawner = shellSpawner;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            _shellSpawner.Create(_shellPoint.position, Quaternion.identity,
                _shellImpulse * (_shellPoint.right + _shellPoint.up), 1);
        }
    }
}