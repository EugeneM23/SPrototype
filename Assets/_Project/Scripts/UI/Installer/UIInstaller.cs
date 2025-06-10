using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class UIInstaller : Installer<GameObject, UIInstaller>
    {
        [Inject] private GameObject _HUD;

        public override void InstallBindings()
        {
            Container.InstantiatePrefab(_HUD);
        }
    }
}