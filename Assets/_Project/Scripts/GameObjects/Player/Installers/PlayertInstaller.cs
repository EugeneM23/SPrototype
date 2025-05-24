using DamageNumbersPro;
using Game;
using Gameplay.Installers;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class PlayertInstaller : MonoInstaller
    {
        [SerializeField] private HealtBar healtBar;
        [SerializeField] private ParticleSystem _hitEffect;
        [SerializeField] private PlayerSetings _playerSetings;
        [SerializeField] private Vector3 _healtBarOffset;
        [SerializeField] private DamageNumber _popupPrefab;
        [SerializeField] private Transform _weaponBone;
        [SerializeField] private Entity _entityPrefab;

        public override void InstallBindings()
        {
            Container.Bind<Transform>().WithId(DamageRootID.MelleWeaponRoot).FromInstance(_weaponBone).AsCached();
            
            Container.Bind<Entity>().WithId(CharacterParameterID.CharacterEntity)
                .FromInstance(gameObject.GetComponent<Entity>())
                .AsCached();


            Container
                .BindInterfacesAndSelfTo<Player>()
                .AsSingle()
                .NonLazy();

            PlayerMovementInstaller.Install(Container, _playerSetings);
            PlayerHealthInstaller.Install(Container, _playerSetings.MaxHealth, _healtBarOffset, gameObject.transform,
                healtBar, _popupPrefab);
            PlayerAnimationInstaller.Install(Container);
            PlayerEffectsInstaller.Install(Container, _hitEffect);

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
        }
    }
}