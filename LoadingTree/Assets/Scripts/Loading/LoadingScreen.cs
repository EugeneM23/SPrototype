using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _loadingText;
        [SerializeField] private Slider _slider;

        public void Show()
        {
            Debug.Log("LoadingScreen Show");
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void PrintError(string text)
        {
            _loadingText.text = text;
        }

        public void SetProgress(float progress)
        {
            _slider.value = progress;
        }
    }
}