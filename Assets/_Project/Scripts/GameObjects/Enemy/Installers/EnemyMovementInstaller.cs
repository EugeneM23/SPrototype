using Zenject;

namespace Gameplay
{
    public class EnemyMovementInstaller : Installer<EnemyMovementInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyMoveComponent>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BusyAction>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ChaseAction>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PatrolAction>().AsSingle().NonLazy();
        }
    }
}