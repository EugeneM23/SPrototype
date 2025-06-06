using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyInventoryInstaller : MonoInstaller
    {
        [SerializeField] private Entity _rangeWeapon;
        [SerializeField] private Entity _meleeWeapon;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyInventory>().AsSingle().WithArguments(Container, _rangeWeapon, _meleeWeapon)
                .NonLazy();
        }
    }
}