using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay
{
    public class PlayerSwitchButtonInstaller : MonoInstaller
    {
        [SerializeField] private Button _button;

        public override void InstallBindings()
        {
            Container.Bind<Button>().FromInstance(_button);
        }
    }
}