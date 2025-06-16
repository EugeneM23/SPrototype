using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [Inject] private GameLauncher _gameLauncher;

        private void OnEnable() => _button.onClick.AddListener(() => _gameLauncher.Launch());
    }
}