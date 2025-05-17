/*using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _lootPrefabs;
        [SerializeField] private float jumpDuration;
        [SerializeField] private float jumpPower;
        [SerializeField] private int numJumps;
        private Sequence _sequence;

        private void OnEnable()
        {
            StartCoroutine(nameof(SpawnRoutine));
        }

        private void OnDisable()
        {
            _sequence.Kill();
        }

        private IEnumerator SpawnRoutine()
        {
            foreach (var item in _lootPrefabs)
            {
                GameObject go = Instantiate(item, transform.position, Quaternion.identity);

                Vector3 targetPosition = transform.position + Random.insideUnitSphere * 6;
                targetPosition.y = transform.position.y + 1;
                _sequence = go.transform.DOJump(targetPosition, jumpPower, numJumps, jumpDuration)
                    .SetEase(Ease.Linear);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}*/