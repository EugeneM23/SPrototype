using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyPickUp : MonoBehaviour
    {
        [SerializeField] private Entity _enemy;
        [Inject] private GameFactory _factory;

        private GameObject _viewMesh;
        private bool _IsEnable;

        private void OnEnable()
        {
            _IsEnable = true;
        }

        public void SpawnEnemy()
        {
            var go = _factory.Create(_enemy);
            go.transform.position = transform.position;
            gameObject.GetComponent<Entity>().Dispose();
        }
    }
}