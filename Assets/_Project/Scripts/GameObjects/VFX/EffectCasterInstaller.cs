using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    public class EffectCasterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EffectCaster>()
                .AsSingle()
                .WithArguments(gameObject.GetComponent<Entity>())
                .NonLazy();
            
        }
    }
}