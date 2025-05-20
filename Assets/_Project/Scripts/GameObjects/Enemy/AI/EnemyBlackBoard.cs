using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyBlackBoard : MonoBehaviour
    {
        [field: SerializeField] public float ChaseRange { get; private set; }
        [field: SerializeField] public float AttckRange { get; private set; }
        [field: SerializeField] public float ChaseSpeed { get; private set; }
        [field: SerializeField] public float PatrolSpeed { get; private set; }
        [field: SerializeField] public float AttakRotationSpeed { get; set; }
        [field: SerializeField] public int Damage { get; set; }
        [field: SerializeField] public int Health { get; set; }
        [field: SerializeField] public bool IsPushable { get; set; }
        [field: SerializeField] public string[] AttckAnimations { get; set; }
        
        public bool IsAttacking;
        public bool IsRetreat;
        public bool CanPush;
        public bool IsBusy;
        public bool IsWalking;
        public bool IsRunning;
        public Entity Target;
        public Entity Enemy;
    }
    
    public class EnemyBlackBoardInstaller : MonoInstaller
    {
        [SerializeField] private float _chaseRange;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _chaseSpeed;
        [SerializeField] private float _patrolSpeed;
        [SerializeField] private float _attackRotationSpeed;
        [SerializeField] private int _damage;
        [SerializeField] private int _health;
        [SerializeField] private bool _isPushable;

        public override void InstallBindings()
        {
            Container.Bind<float>().WithId(CharacterParameterID.ChaseRange).FromInstance(_chaseRange).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.AttackRange).FromInstance(_attackRange).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.ChaseSpeed).FromInstance(_chaseSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.PatrolSpeed).FromInstance(_patrolSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.AttackRotationSpeed).FromInstance(_attackRotationSpeed).AsCached();
            Container.Bind<int>().WithId(CharacterParameterID.Damage).FromInstance(_damage).AsCached();
            Container.Bind<int>().WithId(CharacterParameterID.Health).FromInstance(_health).AsCached();
            Container.Bind<bool>().WithId(CharacterParameterID.IsPushable).FromInstance(_isPushable).AsCached();
        }
    }
    public enum CharacterParameterID
    {
        ChaseRange,
        AttackRange,
        ChaseSpeed,
        PatrolSpeed,
        AttackRotationSpeed,
        Damage,
        Health,
        IsPushable,
    }
}