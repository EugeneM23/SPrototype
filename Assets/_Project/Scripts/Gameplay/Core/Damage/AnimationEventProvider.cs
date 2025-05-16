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
            _damageCasterManager.CastDamage(100, 2, 1, _layerMask.value, _damageRoot);
            Debug.Log("Enebled damage cast");
        }
    }
}