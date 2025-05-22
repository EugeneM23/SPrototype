using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EntitySpawnerExample : MonoBehaviour
    {
        [Inject] private IEntitySpawner _spawner;

        [SerializeField] private string prefabName;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var entity = _spawner.Spawn(prefabName);
                entity.transform.position = transform.position;
            }
        }
    }
}