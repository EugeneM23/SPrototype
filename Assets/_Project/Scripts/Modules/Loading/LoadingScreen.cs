using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Gameplay
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _massage;
        [SerializeField] private TextMeshProUGUI _percentage;
        [SerializeField] private Slider _slider;

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void PrintError(string text)
        {
            _massage.text = text;
        }

        public void SetProgress(float progress)
        {
            _slider.value = progress;
            _percentage.text = $"{progress:P0}";
        }
    }
}