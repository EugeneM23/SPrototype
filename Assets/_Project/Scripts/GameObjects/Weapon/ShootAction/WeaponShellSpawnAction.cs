using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponShellSpawnAction : WeaponShootComponent.IAction
    {
        [Inject(Id = WeaponParameterID.ShellImpulse)]
        private float _shellImpulse;

        private readonly GameFactory _factory;
        private readonly Transform _shellPoint;
        private Entity _shellPrefab;

        public WeaponShellSpawnAction(Transform shellPoint, GameFactory factory,
            [Inject(Id = WeaponParameterID.ShellPrefab)]
            Entity shellPrefab)
        {
            _shellPoint = shellPoint;
            _factory = factory;
            _shellPrefab = shellPrefab;
        }

        void WeaponShootComponent.IAction.Invoke()
        {
            Entity shell = _factory.Create(_shellPrefab);
            shell.transform.position = _shellPoint.position;
            shell.transform.rotation = _shellPoint.rotation;
            shell.GetComponent<Shell>().SetImpulse(_shellPoint.right + _shellPoint.up, _shellImpulse);
        }
    }
}