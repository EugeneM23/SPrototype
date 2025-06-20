using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    [CreateAssetMenu(fileName = "EnemyRetreatInstaller", menuName = "Installers/AI/EnemyRetreatInstaller")]
    public class EnemyRetreatInstaller : ScriptableObjectInstaller<EnemyRetreatInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyRetreatDecision>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyRetreatState>()
                .AsSingle()
                .NonLazy();
        }
    }

    [CreateAssetMenu(fileName = "EnemyGrabHookInstaller", menuName = "Installers/AI/EnemyGrabHookInstaller")]
    public class EnemyGrabHookInstaller : ScriptableObjectInstaller<EnemyGrabHookInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyGrabHookDecision>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<EnemyGrabHookState>()
                .AsSingle()
                .NonLazy();
        }
    }

    public class EnemyGrabHookDecision : EnemyDecisionBase
    {
        public override int Priority => 11;

        public EnemyGrabHookDecision(PlayerCharacterProvider playerCharacterProvider, Entity entity,
            CharacterConditions conditions) : base(playerCharacterProvider, entity, conditions)
        {
        }

        protected override bool IsOnCondition(float distance) => distance > 10f;
        protected override Type GetTargetState() => typeof(EnemyGrabHookState);
    }

    public class EnemyGrabHookState : IState
    {
        private readonly TargetComponent _targetComponent;
        private readonly Entity _enemy;

        public EnemyGrabHookState(TargetComponent targetComponent, Entity enemy)
        {
            _targetComponent = targetComponent;
            _enemy = enemy;
        }

        public void Enter()
        {
            _targetComponent.Target.GetComponent<Entity>().Get<GameKarnel>().enabled = false;
        }

        public void Update(float deltaTime)
        {
            var direction = _enemy.transform.position - _targetComponent.Target.transform.position;
            _targetComponent.Target.transform.position = Vector3.MoveTowards(_targetComponent.Target.transform.position,
                _enemy.transform.position, Time.deltaTime * 50f);
        }

        public void Exit()
        {
        }
    }
}