using UnityEngine;

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
}