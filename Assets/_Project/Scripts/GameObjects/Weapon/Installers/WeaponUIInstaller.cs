using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponUIInstaller : MonoInstaller
    {
        [SerializeField] private ClipUI _clipUI;
        [SerializeField] private ReloadStatusUI _reloadStatus;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ReloadStatusUI>().FromComponentInNewPrefab(_reloadStatus).AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<ClipUI>().FromComponentInNewPrefab(_clipUI).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ClipUIPresentor>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ReloadStatusUIPresentor>().AsSingle().NonLazy();
        }
    }
}