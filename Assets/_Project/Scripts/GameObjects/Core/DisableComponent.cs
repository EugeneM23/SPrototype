using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class DisableComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _first;
        [SerializeField] private GameObject _second;

        private void OnEnable()
        {
            _first.SetActive(true);
        }

        private void OnDisable()
        {
            _first.SetActive(false);
            _second.SetActive(false);
        }
    }
}