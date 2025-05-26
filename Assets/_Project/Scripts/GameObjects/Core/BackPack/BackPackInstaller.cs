using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BackPackInstaller : MonoInstaller
    {
        [SerializeField] private int _bulletCount;
        [SerializeField] private List<Entity> _weapons;

        public override void InstallBindings()
        {
            Container.Bind<int>()
                .WithId(WeaponParameterID.BulletCount)
                .FromInstance(_bulletCount)
                .AsCached();


            Container.BindInterfacesAndSelfTo<Inventory>().AsSingle().WithArguments(_weapons, Container, _bulletCount)
                .NonLazy();
        }
    }
}