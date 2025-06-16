using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class DamageScreenView : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Image _image;
        [Inject] private readonly PlayerCharacterProvider _playerCharacterProvider;
        private Coroutine _routine;

        private void OnEnable()
        {
            _playerCharacterProvider.Character.Get<HealthComponent>().OnTakeDamaged += Animate;
        }

        private void Animate(int obj)
        {
            if (_routine != null) return;

            _routine = StartCoroutine(FadeSprite(_duration));
        }

        public IEnumerator FadeSprite(float duration)
        {
            Color color = _image.color;
            float halfDuration = duration * 0.5f;

            for (float t = 0; t < halfDuration; t += Time.deltaTime)
            {
                color.a = t / halfDuration;
                _image.color = color;
                yield return null;
            }

            for (float t = 0; t < halfDuration; t += Time.deltaTime)
            {
                color.a = 1f - (t / halfDuration);
                _image.color = color;
                yield return null;
            }

            color.a = 0f;
            _image.color = color;
            _routine = null;
        }
    }
}