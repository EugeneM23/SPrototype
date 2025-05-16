using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class AnimationEventProvider : MonoBehaviour
    {
        [Inject] private readonly EnemyBlackBoard _blackBoard;
        [Inject] private readonly DamageCasterManager _damageCasterManager;

        [SerializeField] private Transform _damageRoot;
        [SerializeField] private LayerMask _layerMask;

        private Transform _sourceObject;

        public void EnebleDamageCast(string castRoot)
        {
            DamageCastParams damageCast = new DamageCastParams(_blackBoard.Damage, 1, 1, _layerMask.value, _damageRoot);
            _damageCasterManager.CastDamage(damageCast);
        }
    }
}