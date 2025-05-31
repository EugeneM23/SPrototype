using Zenject;

namespace Gameplay
{
    public class CharacterStats
    {
        [Inject(Id = CharacterParameterID.MaxHealth, Optional = true)]
        private int _maxHealth;

        [Inject(Id = CharacterParameterID.Damage, Optional = true)]
        private int _damage;

        [Inject(Id = CharacterParameterID.ChaseSpeed, Optional = true)]
        private float _chaseSpeed;

        [Inject(Id = CharacterParameterID.PatrolSpeed, Optional = true)]
        private float _patrolSpeed;

        [Inject(Id = CharacterParameterID.RunSpeed, Optional = true)]
        private float _runSpeed;

        [Inject(Id = CharacterParameterID.RotationSpeed, Optional = true)]
        private float _rotationSpeed;

        [Inject(Id = CharacterParameterID.LookAtSpeed, Optional = true)]
        private float _lookAtSpeed;

        [Inject(Id = CharacterParameterID.StrafeSpeed, Optional = true)]
        private float _strafeSpeed;

        [Inject(Id = CharacterParameterID.StrafePower, Optional = true)]
        private float _strafePower;

        [Inject(Id = CharacterParameterID.AttackRotationSpeed, Optional = true)]
        private float _attackRotationSpeed;

        [Inject(Id = CharacterParameterID.AttackRange, Optional = true)]
        private float _attackRange;

        [Inject(Id = CharacterParameterID.ChaseRange, Optional = true)]
        private float _chaseRange;

        [Inject(Id = CharacterParameterID.MoveSpeed, Optional = true)]
        private float _moveSpeed;

        [Inject(Id = CharacterParameterID.IsPushable, Optional = true)]
        private bool _isPushable;

        [Inject(Id = CharacterParameterID.CharacterEntity, Optional = true)]
        private Entity _characterEntity;

        private float _fireRateMultupleyer = 1;

        public int MaxHealth => _maxHealth;
        public int Damage => _damage;
        public float ChaseSpeed => _chaseSpeed;
        public float PatrolSpeed => _patrolSpeed;

        public float RunSpeed => _runSpeed;

        public float RotationSpeed => _rotationSpeed;
        public float LookAtSpeed => _lookAtSpeed;
        public float StrafeSpeed => _strafeSpeed;
        public float StrafePower => _strafePower;
        public float AttackRotationSpeed => _attackRotationSpeed;
        public float AttackRange => _attackRange;
        public float ChaseRange => _chaseRange;
        public float MoveSpeed => _moveSpeed;

        public bool IsPushable => _isPushable;
        public Entity CharacterEntity => _characterEntity;

        public float FireRateMultupleyer
        {
            get => _fireRateMultupleyer;
            set => _fireRateMultupleyer = value;
        }
    }
}