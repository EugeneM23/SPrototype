using Zenject;

namespace Gameplay.Weapon
{
    public class EnemyWeaponController : IInitializable
    {
        private readonly WeaponFireController _fireController;
        private readonly EnemyRangeAttackState _state;

        public EnemyWeaponController(WeaponFireController fireController, EnemyRangeAttackState state)
        {
            _fireController = fireController;
            _state = state;
        }

        public void Initialize()
        {
            _state.OnEnter += _fireController.TurnOn;
            _state.OnExit += _fireController.TurnOff;
        }
    }
}