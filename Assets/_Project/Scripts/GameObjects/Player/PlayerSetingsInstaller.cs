using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerSetingsInstaller : MonoInstaller
    {
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _lookAtSpeed;
        [SerializeField] private float _strafeSpeed;
        [SerializeField] private float _strafePower;
        [SerializeField] private int _maxHealth;

        public override void InstallBindings()
        {
            Container.Bind<float>().WithId(CharacterParameterID.RunSpeed).FromInstance(_runSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.RotationSpeed).FromInstance(_rotationSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.LookAtSpeed).FromInstance(_lookAtSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.StrafeSpeed).FromInstance(_strafeSpeed).AsCached();
            Container.Bind<float>().WithId(CharacterParameterID.StrafePower).FromInstance(_strafePower).AsCached();
            Container.Bind<int>().WithId(CharacterParameterID.MaxHealth).FromInstance(_maxHealth).AsCached();

            Container
                .Bind<CharacterStats>()
                .AsSingle()
                .NonLazy();
        }
    }
}