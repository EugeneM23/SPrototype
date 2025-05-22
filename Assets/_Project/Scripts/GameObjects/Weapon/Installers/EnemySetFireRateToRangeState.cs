using Zenject;

namespace Gameplay
{
    public class EnemySetFireRateToRangeState : IInitializable
    {
        [Inject(Id = WeaponParameterID.FireRate)]
        public float fireRate;

        private EnemyRangeAttackState _state;

        public EnemySetFireRateToRangeState(EnemyRangeAttackState state)
        {
            _state = state;
        }

        public void Initialize()
        {
            _state.SetFireRate(fireRate);
        }
    }
}