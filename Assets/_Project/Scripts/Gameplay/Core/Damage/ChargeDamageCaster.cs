using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ChargeDamageCaster : MonoBehaviour
    {
        [SerializeField] private Transform _characterSkeleton;
        [Inject] private readonly DamageCaster _damageCaster;

        private Transform _sourceObject;

        public void ChargeDamageCast(string castRoot, int damage)
        {
            _sourceObject = GetCastRoot(castRoot);
            _damageCaster.CastOn(_sourceObject, damage);
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