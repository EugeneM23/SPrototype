using Gameplay;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerEffectsInstaller : Installer<ParticleSystem, PlayerEffectsInstaller>
    {
        [Inject] private readonly ParticleSystem _hitEffect;

        public override void InstallBindings()
        {
            Container
                .Bind<PlayEffectComponent>()
                .AsSingle()
                .WithArguments(_hitEffect).NonLazy();
        }
    }
}