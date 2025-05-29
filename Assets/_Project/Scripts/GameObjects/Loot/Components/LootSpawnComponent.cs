using System.Collections;
using Gameplay.Components;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class LootSpawnComponent : MonoBehaviour
    {
        [SerializeField] private Entity[] lootPrefabs;
        [SerializeField] private float moveTime = 1f;
        [SerializeField] private float curveHeight = 3f;
        [SerializeField] private float _radius = 3f;

        [Inject] private readonly GameFactory pool;

        public void SpawnLoot(Entity enemy)
        {
            float delay = 0;
            foreach (var item in lootPrefabs)
            {
                var go = pool.Create(item);
                var startPos = enemy.transform.position;
                var endPos = Random.insideUnitSphere * _radius;
                endPos.y = 0;
                endPos += enemy.transform.position;
                delay += 0.05f;

                go.GetComponent<LootMoverComponent>().MoveTo(startPos, endPos, moveTime + delay, curveHeight, delay);
            }
        }
    }
}