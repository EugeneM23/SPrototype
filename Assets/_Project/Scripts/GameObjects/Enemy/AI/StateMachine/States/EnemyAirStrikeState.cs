using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyAirStrikeState : IState
    {
        private const float AirStrikeDelay = 2f;
        private const int RotationSpeed = 5;
        private const float RotationDuration = 2f;
        private const string AirStrikePrefabPath = "Prefabs/Projectile_Bullet";
        private const string ChargeAnimation = "Charge";

        private readonly CharacterConditions _conditions;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyAttackAssistComponent _assistComponent;
        private readonly Animator _animator;
        private readonly DiContainer _container;
        private readonly LayerMask _layerMask;
        private readonly Entity _root;
        private readonly GameFactory _factory;
        private float _timer;

        private readonly TargetComponent _targetComponent;
        private bool _isComplete;

        public EnemyAirStrikeState(
            CharacterConditions conditions,
            NavMeshAgent navMeshAgent,
            EnemyAttackAssistComponent assistComponent,
            Animator animator,
            DiContainer container,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity root,
            GameFactory factory, LayerMask layerMask, TargetComponent targetComponent)
        {
            _conditions = conditions;
            _navMeshAgent = navMeshAgent;
            _assistComponent = assistComponent;
            _animator = animator;
            _container = container;
            _root = root;
            _factory = factory;
            _layerMask = layerMask;
            _targetComponent = targetComponent;
        }

        public void Enter()
        {
            _navMeshAgent.enabled = false;
            _isComplete = false;
            _timer = AirStrikeDelay;

            PlayChargeAnimation();


            SpawnRoketsAsync();
            //SpawnRoket();

            // SpawnAirStrike();
            SetBlackBoardFlags(isBusy: true, isAttacking: true, canPush: false);

            _assistComponent.RotateToTarget(_root.Get<TargetComponent>().Target, _root.transform, RotationSpeed,
                RotationDuration);
        }

        private async UniTaskVoid SpawnRoketsAsync()
        {
            for (int i = 0; i < RocketCount; i++)
            {
                SpawnRoket();

                if (i < RocketCount - 1)
                    await UniTask.WaitForSeconds(RocketSpawnDelay);
            }
        }

        public float RocketSpawnDelay = 0.2f;
        private int RocketCount = 10;

        private void SpawnRoket()
        {
            GameObject airStrikePrefab = Resources.Load<GameObject>(AirStrikePrefabPath);
            GameObject go = _container.InstantiatePrefab(airStrikePrefab);

            Entity entity = go.GetComponent<Entity>();

            entity.Get<BulletCollisionComponent>().ResetRaycastPosition(_root.transform.position);
            entity.Get<IBulletMoveComponent>().SetPositionAndRotation(_root.transform.position, Quaternion.identity);
            entity.Get<IBulletMoveComponent>().SetSeed(14);
            entity.Get<BulletCollisionComponent>().SetCollisionLayer(_layerMask);
            entity.Get<BulletDamageAction>().SetDamage(100);

            if (entity.TryGet<BulletProjectileMoveComponent>(out var component))
            {
                component.UpPoint = 30;
                Vector3 position = _targetComponent.Target.transform.position + Random.insideUnitSphere * 10;
                position.y = 0;
                component.SetTargetPos(position);
            }
        }

        public void Update(float deltaTime)
        {
            if (_isComplete)
                return;

            _timer -= deltaTime;
            if (_timer <= 0f)
            {
                _isComplete = true;
                _conditions.IsBusy = false;
            }
        }

        public void Exit()
        {
            _navMeshAgent.enabled = true;
            _timer = AirStrikeDelay;

            SetBlackBoardFlags(isBusy: false, isAttacking: false, canPush: true);
        }

        private void PlayChargeAnimation()
        {
            _animator.Play(ChargeAnimation);
        }

        private void SpawnAirStrike()
        {
            var airStrikePrefab = Resources.Load<GameObject>(AirStrikePrefabPath);
            Vector3 targetPosition = _root.Get<TargetComponent>().Target.transform.position;
            GameObject go = _container.InstantiatePrefab(airStrikePrefab);
            go.transform.SetParent(null);
            go.transform.position = targetPosition;
        }

        private void SetBlackBoardFlags(bool isBusy, bool isAttacking, bool canPush)
        {
            _conditions.IsBusy = isBusy;
            _conditions.CanPush = canPush;
        }
    }
}