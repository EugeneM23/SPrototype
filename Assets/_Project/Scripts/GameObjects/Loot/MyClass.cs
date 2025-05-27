using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class MyClass : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [Inject] private readonly GameFactory _pool;
        private float _timer;

        private void Start()
        {
            _pool.Create(_entity);
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                var asd = _pool.Create(_entity);

                var pos = Random.insideUnitSphere * 4f;
                pos.y = 0;
                asd.transform.position = pos;
                _timer = 2f;
            }
        }
    }
}