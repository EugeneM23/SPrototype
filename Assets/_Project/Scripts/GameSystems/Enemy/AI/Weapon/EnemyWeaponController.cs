using UnityEngine;
using Zenject;

namespace Gameplay.Weapon
{
    public class EnemyWeaponController : IInitializable
    {
        private readonly WeaponFireController _fireController;
        private readonly Enemy _enemy;

        public EnemyWeaponController(WeaponFireController fireController, Enemy enemy)
        {
            _fireController = fireController;
            _enemy = enemy;
        }

        public void Initialize()
        {
            _fireController.TurnOn();
        }
    }
}