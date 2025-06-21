using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class GrabHookMover : ILateTickable, IInitializable
    {
        private GrabHook _grabHook;
        private readonly TargetComponent _target;
        private readonly Entity _entity;
        private readonly Animator _animator;
        private readonly Transform _root;
        private readonly CharacterConditions _conditions;
        private readonly NavMeshAgent _navMeshAgent;

        private float speed = 50f;
        private float distance = 20f;

        public Vector3 startPos;
        public Vector3 moveToPos;
        public bool movingAway = true;

        public GrabHookMover(
            TargetComponent target,
            Entity entity,
            [Inject(Id = DamageRootID.RangeWeaponRoot)]
            Transform root, Animator animator, CharacterConditions conditions, NavMeshAgent navMeshAgent,
            GrabHook grabHook)
        {
            _target = target;
            _entity = entity;
            _root = root;
            _animator = animator;
            _conditions = conditions;
            _navMeshAgent = navMeshAgent;
            _grabHook = grabHook;
        }

        public void Initialize()
        {
            _grabHook.OnGrab += () => movingAway = false;
        }

        public void DO()
        {
            startPos = _entity.transform.position;
            Vector3 direction = _entity.gameObject.transform.forward.normalized;
            moveToPos = startPos + (direction * distance);
            moveToPos.y += 2;
        }

        public void LateTick()
        {
            if (movingAway)
            {
                _root.position = Vector3.MoveTowards(_root.position, moveToPos, speed * Time.deltaTime);
                if (Vector3.Distance(_root.position, moveToPos) < 1f)
                    movingAway = false;
            }
            else
            {
                _root.position =
                    Vector3.MoveTowards(_root.position, _entity.transform.position,
                        speed * Time.deltaTime);

                if (Vector3.Distance(_root.position, _entity.transform.position) < 1f)
                {
                    _conditions.CanPush = true;
                    _navMeshAgent.enabled = true;
                    _conditions.IsBusy = false;
                    movingAway = true;
                }
            }
        }
    }
}