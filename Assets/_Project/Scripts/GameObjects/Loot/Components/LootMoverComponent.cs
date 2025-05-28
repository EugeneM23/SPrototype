using System.Collections;
using UnityEngine;

namespace Gameplay.Components
{
    public class LootMoverComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _view;

        public void MoveTo(Vector3 start, Vector3 end, float time, float height = 3f, float delay = 0)
        {
            transform.position = start;
            StartCoroutine(Move(start, end, time, height, delay));
        }

        private IEnumerator Move(Vector3 start, Vector3 end, float time, float height, float delay = 0)
        {
            _view.SetActive(false);
            yield return new WaitForSeconds(delay);
            _view.SetActive(true);

            float elapsed = 0f;
            Vector3 mid = (start + end) * 0.5f;
            mid.y += height;

            // Рандомная скорость вращения от -720 до 720 градусов в секунду
            float rotationSpeed = Random.Range(-720f, 720f);

            while (elapsed < time)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / time;
                float u = 1f - t;

                // Движение по параболе
                transform.position = u * u * start + 2f * u * t * mid + t * t * end;

                // Вращение _view вокруг оси X
                _view.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

                yield return null;
            }

            transform.position = end;
            _view.transform.rotation = Quaternion.identity;
        }
    }
}