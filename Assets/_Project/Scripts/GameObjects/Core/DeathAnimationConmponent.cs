using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class DeathAnimationConmponent : ITickable, IInitializable
    {
        private readonly Animator _animator;
        private readonly Entity _characterEntity;
        private float _time;
        private bool _isActive;
        private int _layer;

        public DeathAnimationConmponent(Animator animator, Entity characterEntity)
        {
            _animator = animator;
            _characterEntity = characterEntity;
        }

        public void Initialize()
        {
            _layer = _characterEntity.gameObject.layer;
            Debug.Log(_layer);
        }

        public void ActiveteAnimation()
        {
            _characterEntity.Get<CharacterConditions>().IsAlive = false;
            _characterEntity.Get<NavMeshAgent>().enabled = false;
            _characterEntity.Get<HealtBar>().gameObject.SetActive(false);
            _characterEntity.Get<CapsuleCollider>().enabled = false;
            _characterEntity.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            _isActive = true;
            _time = 10;
            _animator.Play("Death");
        }

        public void DeactiveteAnimation()
        {
            _characterEntity.gameObject.layer = _layer;
            _characterEntity.Get<CharacterConditions>().IsAlive = true;
            _characterEntity.Get<NavMeshAgent>().enabled = true;
            _characterEntity.Get<HealtBar>().gameObject.SetActive(true);
            _characterEntity.Get<CapsuleCollider>().enabled = true;
        }

        public void Tick()
        {
            if (_isActive)
            {
                _time -= Time.deltaTime;
                if (_time <= 0)
                {
                    DeactiveteAnimation();
                    _characterEntity.Dispose();
                    _isActive = false;
                }
            }
        }
    }
}