using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class AirStrikeSpawner : MonoBehaviour
    {
        [Inject] private readonly Transform _player;
        [SerializeField] private GameObject _airStrikePrefab;

        public void Spawn()
        {
            var go = Instantiate(_airStrikePrefab);
            Vector3 position = _player.position;
            position.y = 0;
            go.transform.position = position;
        }
    }
}