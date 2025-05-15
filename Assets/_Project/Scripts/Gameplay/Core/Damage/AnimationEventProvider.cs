using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class AnimationEventProvider : MonoBehaviour
    {
        [Inject] private readonly EnemyBlackBoard _blackBoard;
        [Inject] private readonly DamageCaster _damageCaster;

        [SerializeField] private Transform _characterSkeleton;

        private Transform _sourceObject;

        public void EnebleDamageCast(string castRoot)
        {
            _sourceObject = GetCastRoot(castRoot);
            _damageCaster.CastOn(_sourceObject, _blackBoard.Damage);
        }

        public void DisableDamageCast()
        {
            _damageCaster.CastOff();
        }

        private Transform GetCastRoot(string castRoot)
        {
            Transform[] allBones = _characterSkeleton.GetComponentsInChildren<Transform>(true);

            foreach (Transform bone in allBones)
                if (bone.name == castRoot)
                    return bone;

            return null;
        }
    }
}