using Zenject;

namespace Gameplay
{
    public class CharacterStats
    {
        [Inject(Id = CharacterParameterID.MaxHealth, Optional = true)]
        public int MaxHealth { get; private set; }

        [Inject(Id = CharacterParameterID.Damage, Optional = true)]
        public int Damage { get; private set; }

        [Inject(Id = CharacterParameterID.ChaseSpeed, Optional = true)]
        public float ChaseSpeed { get; private set; }

        [Inject(Id = CharacterParameterID.PatrolSpeed, Optional = true)]
        public float PatrolSpeed { get; private set; }

        [Inject(Id = CharacterParameterID.RunSpeed, Optional = true)]
        public float RunSpeed { get; private set; }

        [Inject(Id = CharacterParameterID.RotationSpeed, Optional = true)]
        public float RotationSpeed { get; private set; }

        [Inject(Id = CharacterParameterID.LookAtSpeed, Optional = true)]
        public float LookAtSpeed { get; private set; }

        [Inject(Id = CharacterParameterID.StrafeSpeed, Optional = true)]
        public float StrafeSpeed { get; private set; }

        [Inject(Id = CharacterParameterID.StrafePower, Optional = true)]
        public float StrafePower { get; private set; }

        [Inject(Id = CharacterParameterID.AttackRotationSpeed, Optional = true)]
        public float AttackRotationSpeed { get; private set; }

        [Inject(Id = CharacterParameterID.AttackRange, Optional = true)]
        public float AttackRange { get; private set; }

        [Inject(Id = CharacterParameterID.ChaseRange, Optional = true)]
        public float ChaseRange { get; private set; }

        [Inject(Id = CharacterParameterID.MoveSpeed, Optional = true)]
        public float MoveSpeed { get; private set; }

        [Inject(Id = CharacterParameterID.IsPushable, Optional = true)]
        public bool IsPushable { get; private set; }

        [Inject(Id = CharacterParameterID.CharacterEntity, Optional = true)]
        public Entity CharacterEntity { get; private set; }

        public float FireRateMultupleyer { get; set; }
        public float RunSpeedMultiplayer { get; set; }
    }
}