using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponTypeInstaller : MonoInstaller
    {
        [SerializeField] private WeaponType _type;

        public override void InstallBindings()
        {
            Container
                .Bind<WeaponTypeHandler>()
                .AsSingle()
                .WithArguments(_type)
                .NonLazy();
        }
    }
}