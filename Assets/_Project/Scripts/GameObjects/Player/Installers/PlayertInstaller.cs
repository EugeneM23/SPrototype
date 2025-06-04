using DamageNumbersPro;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayertInstaller : MonoInstaller
    {
        [SerializeField] private HealtBar healtBar;
        [SerializeField] private Vector3 _healtBarOffset;
        [SerializeField] private DamageNumber _popupPrefab;
        [SerializeField] private Transform _weaponBone;

        public override void InstallBindings()
        {
            Container.Bind<Transform>().WithId(DamageRootID.MeleeWeaponRoot).FromInstance(_weaponBone).AsCached();

            Container
                .Bind<Entity>()
                .WithId(CharacterParameterID.CharacterEntity)
                .FromInstance(gameObject.GetComponent<Entity>())
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<Player>()
                .AsSingle()
                .NonLazy();

            PlayerMovementInstaller.Install(Container);
            PlayerHealthInstaller.Install(Container, _healtBarOffset, gameObject.transform,
                healtBar, _popupPrefab);
            PlayerAnimationInstaller.Install(Container);

            Container
                .BindInterfacesAndSelfTo<PlayerWeaponManager>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PlayerCameraController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<TargetComponent>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<BuffManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}