using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class RageUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Slider _slider;

        private void OnEnable()
        {
            _text.text = "X 1";
        }

        public void UpdateStack(int stackCount)
        {
            _text.text = "X " + stackCount;
        }

        public void UpdateSlider(float remainingTime, float totalDuration)
        {
            _slider.value = remainingTime / totalDuration;
        }
    }
}