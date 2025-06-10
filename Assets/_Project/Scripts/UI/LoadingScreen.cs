using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _text;

        public void Hide() => _loadingScreen.SetActive (false);
        public void Show() => _loadingScreen.SetActive(true);

        public void SetProgress(int value) => _slider.value = value;

        public void SetError(string loadingFailed) => _text.text = loadingFailed;
    }
}