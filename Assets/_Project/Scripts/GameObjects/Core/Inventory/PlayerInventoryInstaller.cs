using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerInventoryInstaller : MonoInstaller
    {
        [SerializeField] private int _bulletCount;
        [SerializeField] private List<Entity> _weapons;

        public override void InstallBindings()
        {
            Container.Bind<int>()
                .WithId(WeaponParameterID.BulletCount)
                .FromInstance(_bulletCount)
                .AsCached();

            Container.BindInterfacesAndSelfTo<PlayerInventory>().AsSingle()
                .WithArguments(_weapons, Container, _bulletCount)
                .NonLazy();
        }
    }
}