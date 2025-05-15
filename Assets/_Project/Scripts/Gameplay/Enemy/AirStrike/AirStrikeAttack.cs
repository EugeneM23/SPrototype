using System.Collections;
using UnityEngine;

namespace Gameplay
{
    internal class AirStrikeAttack : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToPlace;
        [SerializeField] private float radius;

        private void OnEnable()
        {
            StartCoroutine(AttackRoutine());
            StartCoroutine(LifeRoutine());

            foreach (GameObject obj in objectsToPlace)
            {
                Vector2 randomCircle = Random.insideUnitCircle * radius;
                Vector3 randomPosition = new Vector3(randomCircle.x, 0, randomCircle.y);
                obj.transform.position = gameObject.transform.position + randomPosition;
            }
        }

        private IEnumerator AttackRoutine()
        {
            yield return new WaitForSeconds(0.3f);

            int count = objectsToPlace.Length;
            while (count > 0)
            {
                foreach (GameObject obj in objectsToPlace)
                {
                    yield return new WaitForSeconds(0.1f);
                    obj.GetComponent<Animation>().Play("AirStrike");
                    count--;
                }
            }
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSeconds(5);
            Destroy(this.gameObject);
        }
    }
}