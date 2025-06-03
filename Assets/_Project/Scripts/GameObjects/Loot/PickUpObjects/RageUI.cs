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
        private float totalDuration;

        private void OnEnable()
        {
            _text.text = "X 1";
        }

        public void SetStuck(int stackCount)
        {
            Debug.Log(stackCount);
            _text.text = "X " + stackCount;
        }

        public void UpdateSlider(float remainingTime)
        {
            if (totalDuration > 0f)
                _slider.value = Mathf.Clamp01((totalDuration - remainingTime) / totalDuration);
            else
                _slider.value = 0f;
        }

        public void SetDuration(float duration)
        {
            totalDuration = duration;
        }
    }
}