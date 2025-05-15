using UnityEngine;

namespace Gameplay
{
    public class WeaponShellSpawnComponent : WeaponShootComponent.IAction
    {
        private readonly Transform _shellPoint;
        private IShellSpawner _shellSpawner;
        private readonly WeaponSetings _setings;

        public WeaponShellSpawnComponent(Transform shellPoint, IShellSpawner shellSpawner,
            WeaponSetings setings)
        {
            _shellPoint = shellPoint;
            _shellSpawner = shellSpawner;
            _setings = setings;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            _shellSpawner.Create(_shellPoint.position, Quaternion.identity,
                _setings.ShellImpulse * _shellPoint.right, 1);
        }
    }
}