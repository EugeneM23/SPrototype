using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class RageUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void UpdateStack(int stackCount) => _text.text = "X " + stackCount.ToString();
    }
}